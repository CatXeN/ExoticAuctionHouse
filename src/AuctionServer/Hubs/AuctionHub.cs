using AuctionServer.Data;
using Microsoft.AspNetCore.SignalR;

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

        public async Task SendMessage(string user, string auctionId, string price) // Changed parameters to works should change parameters in front-end
        {
            //_context.Auctions.

            await Clients.All.SendAsync("ReceiveMessage", user, $"Price 10");
        }
    }
}
