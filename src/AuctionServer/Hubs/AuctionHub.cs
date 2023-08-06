using AuctionServer.Data;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace AuctionServer.Hubs
{
    public class AuctionHub : Hub
    {
        private DataContext _context;

        public AuctionHub(DataContext context)
        {
            _context = context;
        }

        // add database

        //public async Task SendMessage(string user, string message)
        //    => await Clients.All.SendAsync("ReceiveMessage", user, message);

        public async Task SendMessage(Guid user, Guid auctionId, decimal price) // Changed parameters to works should change parameters in front-end
        {
            var auction = await _context.Bets
                .FirstOrDefaultAsync(b => b.AuctionId == auctionId);

            if (auction == null)
                return;

            auction.CurrentPrice = price;
            auction.LastUserId = user;
            auction.LastTime = DateTime.UtcNow;

            _context.Bets.Update(auction);
            await _context.SaveChangesAsync();

            await Clients.All.SendAsync("ReceiveMessage", user, auction.CurrentPrice);
        }
    }
}
