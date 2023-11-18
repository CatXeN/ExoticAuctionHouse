using ExoticAuctionHouse_API.Data;
using ExoticAuctionHouseModel.Enums;
using ExoticAuctionHouseModel.Informations;
using ExoticAuctionHouseModel.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ExoticAuctionHouse_API.Repositories.Auctions
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly DataContext _context;

        public AuctionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Add(AuctionInformation auction)
        {
            var auctionToAdd = new Auction
            {
                AmountStarting = auction.AmountStarting,
                BiddingBegins = auction.BiddingBegins,
                CarId = auction.CarId,
                CreatedAt = auction.CreatedAt,
                CurrentPrice = auction.CurrentPrice,
                Location = auction.Location,
                IsEnd = false
            };

            await _context.AddAsync(auctionToAdd);
            await _context.SaveChangesAsync();
        }

        public async Task End(Guid[] ids)
        {
            var auctions = _context.Auctions.Where(a => ids.Contains(a.Id));
            var endedAuctions = auctions.Select(a => new Auction()
            {
                Id = a.Id,
                AmountStarting = a.AmountStarting,
                BiddingBegins = a.BiddingBegins,
                CarId = a.CarId,
                CreatedAt = a.CreatedAt,
                CurrentPrice = a.CurrentPrice,
                Location = a.Location,
                IsEnd = true
            });

            _context.UpdateRange(endedAuctions);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Auction>> Get()
        {
            var cars = await _context.Auctions.Include(x => x.Car).ToListAsync();
            return cars;
        }

        public IQueryable<Auction> GetAuctionWithCarsQuerable(string brand) => _context.Auctions
            .Include(x => x.Car)
            .AsQueryable();

        public async Task<Auction> GetById(Guid id)
        {
            var auction = await _context.Auctions.Include(a => a.Car).FirstOrDefaultAsync(a => a.Id == id);

            return auction ?? throw new InvalidDataException($"Auction with id {id}");
        }

        public async Task<IEnumerable<Auction>> GetNotEnded()
        {
            var cars = await _context.Auctions
                .Include(x => x.Car)
                .Where(a => !a.IsEnd)
                .ToListAsync();

            return cars;
        }

        public async Task Update(UpdateAuctionInformation auction)
        {
            var auctionToUpadate = new Auction()
            {
                AmountStarting = auction.AmountStarting,
                BiddingBegins = auction.BiddingBegins,
                CarId = auction.CarId,
                CreatedAt = auction.CreatedAt,
                CurrentPrice = auction.CurrentPrice,
                Id = auction.Id,
                IsEnd = auction.IsEnd,
                Location = auction.Location,
            };

            _context.Auctions.Update(auctionToUpadate);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Auction auction)
        {
            _context.Auctions.Update(auction);
            await _context.SaveChangesAsync();
        }
    }
}
