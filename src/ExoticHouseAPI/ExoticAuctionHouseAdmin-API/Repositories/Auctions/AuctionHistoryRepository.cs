using ExoticAuctionHouse_API.Data;
using ExoticAuctionHouseModel.Informations;
using ExoticAuctionHouseModel.Models;
using Microsoft.EntityFrameworkCore;

namespace ExoticAuctionHouse_API.Repositories.Auctions
{
    public class AuctionHistoryRepository : IAuctionHistoryRepository
    {
        private readonly DataContext _context;

        public AuctionHistoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Add(AuctionHistory[] auctionHistory)
        {
            await _context.AuctionHistory.AddRangeAsync(auctionHistory);
            await _context.SaveChangesAsync();
        }

        public async Task Add(AuctionHistory auctionHistory)
        {
            await _context.AuctionHistory.AddAsync(auctionHistory);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AuctionHistory>> Get()
        {
            var auctions = await _context.AuctionHistory.ToListAsync();
            return auctions;
        }

        public async Task<AuctionHistory> GetById(Guid id)
        {
            var auction = await _context.AuctionHistory
                .FirstOrDefaultAsync(auction => auction.Id == id);

            return auction ?? throw new InvalidOperationException();
        }

        public async Task<IEnumerable<AuctionHistory>> MyAuctions(Guid UserId)
        {
            var myAuctions = await _context.AuctionHistory
                .Include(x => x.Car)
                .Where(x => x.UserId == UserId)
                .ToListAsync();

            return myAuctions;
        }
    }
}
