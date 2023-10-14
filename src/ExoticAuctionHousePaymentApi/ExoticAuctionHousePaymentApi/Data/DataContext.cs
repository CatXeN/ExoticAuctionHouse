using ExoticAuctionHousePaymentApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExoticAuctionHousePaymentApi.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Payment> Payments { get; set; }
}