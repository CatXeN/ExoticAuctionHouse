using AuctionServer.Data;
using AuthModels.Configs;
using ExoticAuctionHouseModel.Config;
using ExoticAuctionHouseModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Validations;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace AuctionServer.Services
{
    public class TimeHostedService : IHostedService, IDisposable
    {
        private Timer? _timer = null;
        private static HttpClient _httpClient;
        private readonly IServiceScopeFactory _serviceProvider;
        private readonly ServicesConfig _servicesConfig;

        public TimeHostedService(IServiceScopeFactory serviceProvider, IOptions<ServicesConfig> config)
        {
            _serviceProvider = serviceProvider;
            _servicesConfig = config.Value;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(_servicesConfig.ExoticAuctionHouseAPI + "/api/")
            };
        }

        private async void CheckAuctions(object? state)
        {
            var res = await _httpClient.GetAsync("auction/");

            if (res.IsSuccessStatusCode)
            {
                using var scope = _serviceProvider.CreateScope();
                var context = scope.ServiceProvider.GetService<DataContext>();

                if (context == null)
                    return;

                var lunchedAuctions = context.Bets.Select(a => a.AuctionId);
                var auctions = await res.Content.ReadFromJsonAsync<List<Auction>>();

                if (auctions != null && auctions.Any())
                {
                    var newAuctions = auctions.Where(x => !lunchedAuctions.Contains(x.Id) && DateTimeOffset.Now >= x.BiddingBegins)
                        .Select(b => new Bet
                        {
                            Id = Guid.NewGuid(),
                            AuctionId = b.Id,
                            CarId = b.CarId,
                            CurrentPrice = b.AmountStarting,
                            LastTime = b.BiddingBegins,
                            LastUserId = Guid.Empty
                        }).ToList();

                    if (newAuctions.Count > 0)
                    {
                        await context.AddRangeAsync(newAuctions);
                        await context.SaveChangesAsync();
                    }
                }
            }
        }

        private async void BiddingIsEnd(object? state)
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetService<DataContext>();

            if (context == null)
                return;

            var auctions = context.Bets.Where(b => b.LastTime < DateTime.Now.AddMinutes(-2));

            if (auctions.Any())
            {
                var auctionsHistory = auctions.Select(auction => new AuctionHistory()
                {
                    CarId = auction.CarId,
                    IsSold = auction.LastUserId != Guid.Empty,
                    Price = auction.CurrentPrice,
                    SoldAt = auction.LastTime,
                    UserId = auction.LastUserId,
                    Id = auction.AuctionId,
                }).ToList();

                HttpContent body = new StringContent(JsonConvert.SerializeObject(auctionsHistory), Encoding.UTF8, "application/json");
                var res = await _httpClient.PostAsync("auctionHistory/", body);

                if (res.IsSuccessStatusCode)
                {
                    context.Bets.RemoveRange(auctions.ToList());
                    await context.SaveChangesAsync();
                }
            }
        }

        private async void PaymentTimeOut(object? state)
        {
            var _paymentClient = new HttpClient
            {
                BaseAddress = new Uri(_servicesConfig.ExoticAuctionPaymentAPI + "/payment/")
            };
            await _paymentClient.PostAsync("clearTickets", null); //Should security :D
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(CheckAuctions, null, TimeSpan.Zero,
                TimeSpan.FromMinutes(1));

            _timer = new Timer(BiddingIsEnd, null, TimeSpan.Zero,
                TimeSpan.FromMinutes(1));

            _timer = new Timer(PaymentTimeOut, null, TimeSpan.Zero,
                TimeSpan.FromMinutes(1));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose() => _timer?.Dispose();
    }
}
