using AuctionServer.Data;
using ExoticAuctionHouseModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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

        public TimeHostedService(IServiceScopeFactory serviceProvider)
        {
            _serviceProvider = serviceProvider;

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7218/api/") // Should be get from config
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
                    var newAuctions = auctions.Where(x => !lunchedAuctions.Contains(x.Id) && DateTime.Now >= x.BiddingBegins)
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

            var auctions = context.Bets.Where(b => b.LastTime < DateTime.Now.AddMinutes(-1));

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

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(CheckAuctions, null, TimeSpan.Zero,
                TimeSpan.FromMinutes(1));

            _timer = new Timer(BiddingIsEnd, null, TimeSpan.Zero,
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
