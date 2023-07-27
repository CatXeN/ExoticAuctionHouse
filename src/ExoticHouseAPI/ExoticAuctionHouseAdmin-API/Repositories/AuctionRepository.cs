using ExoticAuctionHouse_API.Data;
using ExoticAuctionHouseModel.Enums;
using ExoticAuctionHouseModel.Informations;
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

        public async Task Add(AuctionInformation auction)
        {
            var auctionToAdd = new Auction
            {
                AmountStarting = auction.AmountStarting,
                BiddingBegins = auction.BiddingBegins,
                CarId = auction.CarId,
                CreatedAt = auction.CreatedAt,
                CurrentPrice = auction.CurrentPrice,
                Location = auction.Location
            };

            await _context.AddAsync(auctionToAdd);
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

        public async Task<IEnumerable<Auction>> GetCarsByFilter(SearchModel searchModel)
        {
            var cars = _context.Auctions.Include(x => x.Car).Where(car => car.Car.Brand == searchModel.Brand);

            if (!string.IsNullOrEmpty(searchModel.Model))
                cars = cars.Where(car => car.Car.Model == searchModel.Model);

            if (searchModel.BodyType != BodyType.All)
                cars = cars.Where(car => car.Car.BodyType == searchModel.BodyType);

            if (searchModel.FuelType != FuelType.All)
                cars = cars.Where(car => car.Car.FuelType == searchModel.FuelType);


            return await cars.ToListAsync();
        }
    }
}
