using AuthModels.Models;
using ExoticAuctionHouseModel.Models;
using Microsoft.EntityFrameworkCore;

namespace AuctionServer.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Bet> Bets { get; set; }
    }
}
