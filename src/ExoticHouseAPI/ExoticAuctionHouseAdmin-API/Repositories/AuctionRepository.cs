using ExoticAuctionHouse_API.Data;
using ExoticAuctionHouseModel.Enums;
using ExoticAuctionHouseModel.Informations;
using ExoticAuctionHouseModel.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ExoticAuctionHouse_API.Repositories
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
                Location = auction.Location
            };

            await _context.AddAsync(auctionToAdd);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Auction>> Get()
        {
            var cars = await _context.Auctions.Include(x => x.Car).ToListAsync();
            return cars;
        }

        public IQueryable<Auction> GetAuctionWithCarsQuerable(string brand) => _context.Auctions
            .Include(x => x.Car)
            .Where(car => car.Car.Brand == brand)
            .AsQueryable();

        public async Task<Auction> GetById(Guid id)
        {
            var auction = await _context.Auctions.Include(a => a.Car).FirstOrDefaultAsync(a => a.Id == id);

            return auction ?? throw new InvalidDataException($"Auction with id {id}");
        }

    }
}
