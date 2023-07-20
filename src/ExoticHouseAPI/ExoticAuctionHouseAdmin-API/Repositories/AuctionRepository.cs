using ExoticAuctionHouse_API.Data;
using ExoticAuctionHouseModel.Models;
using Microsoft.EntityFrameworkCore;

namespace ExoticAuctionHouse_API.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly DataContext _context;

        public AuctionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Add(Auction auction)
        {
            await _context.AddAsync(auction);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Auction>> Get()
        {
            var cars = await _context.Auctions.ToListAsync();
            return cars;
        }

        public async Task<Auction> GetById(Guid id)
        {
            var auction = await _context.Auctions.FirstOrDefaultAsync(a => a.Id == id);

            return auction ?? throw new InvalidDataException($"Auction with id {id}");
        }
    }
}
