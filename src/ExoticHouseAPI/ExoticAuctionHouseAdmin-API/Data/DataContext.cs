using ExoticAuctionHouseModel.Models;
using Microsoft.EntityFrameworkCore;

namespace ExoticAuctionHouse_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarAttribute> CarAttributes { get; set; }
        public DbSet<AuctionHistory> AuctionHistory { get; set; }
        public DbSet<Auction> Auctions { get; set; }
    }
}
