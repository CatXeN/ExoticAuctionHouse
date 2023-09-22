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
        private readonly ICarAttributeRepository _carAttributeRepository;
        private readonly IAttributeRepository _attributeRepository;

        public CarService(ICarRepository carRepository, ICarAttributeRepository carAttributeRepository, IAttributeRepository attributeRepository)
        {
            _carRepository = carRepository;
            _carAttributeRepository = carAttributeRepository;
            _attributeRepository = attributeRepository;
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

        public async Task<List<TranslatedAttribute>> GetTranslatedAttribute(Guid carId)
        {
            var carAttributes = await _carAttributeRepository.GetAllAttributesWithInfo(carId);

            return carAttributes.Select(x => new TranslatedAttribute()
            {
                Category = x.Attribute.Category,
                Name = x.Attribute.Value
            }).ToList();
        }
    }
}
