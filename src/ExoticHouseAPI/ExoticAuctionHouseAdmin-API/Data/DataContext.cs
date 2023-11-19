using AuthModels.Models;
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
        public DbSet<User> Users { get; set; }
        public DbSet<ExoticAuctionHouseModel.Models.Attribute> Attributes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExoticAuctionHouseModel.Models.Attribute>()
                .HasData(SeedAttributes.GetAttributes());
        }
    }
}
