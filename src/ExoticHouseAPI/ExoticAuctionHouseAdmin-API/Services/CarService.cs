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

        public Task<Guid> AddCar(AddCarInformation addCarInformation)
        {
            var car = new Car()
            {
                Capacity = addCarInformation.Capacity,
                ProductionDate = addCarInformation.ProductionDate,
                BodyType = addCarInformation.BodyType,
                Brand = addCarInformation.Brand,
                FuelType = addCarInformation.FuelType,
                Generation = addCarInformation.Generation,
                Horsepower = addCarInformation.Horsepower,
                IsSold = false,
                Mileage = addCarInformation.Mileage,
                Model = addCarInformation.Model
            };

            var id = _carRepository.AddCar(car);

            return id;
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
    }
}
