using ExoticAuctionHouse_API.Repositories;
using ExoticAuctionHouseModel.Enums;
using ExoticAuctionHouseModel.Informations;
using ExoticAuctionHouseModel.Models;
using Microsoft.EntityFrameworkCore;

namespace ExoticAuctionHouse_API.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionRepository _repository;

        public AuctionService(IAuctionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Auction>> GetCarsByFilter(SearchModel searchModel)
        {
            var cars = _repository.GetAuctionWithCarsQuerable(searchModel.Brand);

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
