using ExoticAuctionHouse_API.Helpers;
using ExoticAuctionHouse_API.Repositories;
using ExoticAuctionHouseModel.Enums;
using ExoticAuctionHouseModel.Informations;
using ExoticAuctionHouseModel.Models;
using Microsoft.EntityFrameworkCore;

namespace ExoticAuctionHouse_API.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<CarPageData> GetCarPageData()
        {
            CarPageData carPageData = new CarPageData
            {
                Brand = await _carRepository.GetBrands(),
                BodyTypes = EnumHelper.ExtractValues<BodyType>(),
                FuelTypes = EnumHelper.ExtractValues<FuelType>()
            };

            return carPageData;
        }

        public async Task<IEnumerable<Car>> GetCarsByFilter(SearchModel searchModel)
        {
            var cars = _carRepository.GetCarsQueryable(searchModel.Brand);

            if (!string.IsNullOrEmpty(searchModel.Model))
                cars = cars.Where(car => car.Model == searchModel.Model);

            if (searchModel.BodyType != BodyType.All)
                cars = cars.Where(car => car.BodyType == searchModel.BodyType);

            if (searchModel.FuelType != FuelType.All)
                cars = cars.Where(car => car.FuelType == searchModel.FuelType);

            return await cars.ToListAsync();
        }
    }
}
