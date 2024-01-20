using ExoticAuctionHouse_API.Helpers;
using ExoticAuctionHouse_API.Repositories.Auctions;
using ExoticAuctionHouse_API.Repositories.Cars;
using ExoticAuctionHouseModel.Enums;
using ExoticAuctionHouseModel.Informations;
using ExoticAuctionHouseModel.Models;
using FluentFTP;

namespace ExoticAuctionHouse_API.Services.Cars
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarAttributeRepository _carAttributeRepository;
        private readonly IHostEnvironment _hostingEnv;
        private readonly IAuctionRepository _auctionRepository;

        public CarService(ICarRepository carRepository, ICarAttributeRepository carAttributeRepository, IHostEnvironment hostingEnv, IAuctionRepository auctionRepository)
        {
            _carRepository = carRepository;
            _carAttributeRepository = carAttributeRepository;
            _hostingEnv = hostingEnv;
            _auctionRepository = auctionRepository;
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
                Model = addCarInformation.Model,
                Images = "",
                MainImage = "",
                OwnerId = addCarInformation.UserId
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

        public async Task<CommonInformation> SellCar(SellCarInformation sellCarInformation)
        {
            var car = new Car(sellCarInformation.Car);
            var carId = await _carRepository.AddCar(car);

            sellCarInformation.Auction.CarId = carId;
            var auctionId = await _auctionRepository.Add(sellCarInformation.Auction);

            sellCarInformation.AddCarAttributeInformation.CarId = carId;
            await _carAttributeRepository.AddAtribute(sellCarInformation.AddCarAttributeInformation);

            return new CommonInformation() { CarId = carId, AuctionId = auctionId };
        }

        public async Task<List<string>> UploadFiles(List<IFormFile> files, string id)
        {
            var mode = _hostingEnv.IsDevelopment() ? "dev" : "prod";

            var car = await _carRepository.GetCarById(Guid.Parse(id));
            List<string> filesUrls = new List<string>();

            foreach (var file in files)
            {
                var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "images\\",
                    file.FileName);

                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "images"))
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "images");

                using (var stream = File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }

                try
                {
                    var client = new FtpClient("217.182.77.168", "administrator", "QweAsdZxc1231");
                    client.AutoConnect();
                    client.CreateDirectory($"/{mode}/{id}");
                    client.UploadFile(filePath, $"/{mode}/{id}/{file.FileName}");

                    filesUrls.Add($"https://www.image.exoticah.pl/{mode}/{id}/{file.FileName}");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            car.MainImage = filesUrls[0];
            car.Images = string.Join(',', filesUrls);
            await _carRepository.UpdateCar(car);

            return filesUrls;
        }
    }
}
