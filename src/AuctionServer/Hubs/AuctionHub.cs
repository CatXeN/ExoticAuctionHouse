using Microsoft.AspNetCore.SignalR;

namespace AuctionServer.Hubs
{
    public class AuctionHub : Hub
    {
        // add database

        //public async Task SendMessage(string user, string message)
        //    => await Clients.All.SendAsync("ReceiveMessage", user, message);

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, $"Price 10");
        }
    }
}
