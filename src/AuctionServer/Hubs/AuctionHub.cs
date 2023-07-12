using Microsoft.AspNetCore.SignalR;

namespace AuctionServer.Hubs
{
    public class AuctionHub : Hub
    {
        public async Task SendMessage(string user, string message)
            => await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
