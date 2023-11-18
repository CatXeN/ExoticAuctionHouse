using ExoticAuctionHouse_API.Repositories.Auctions;
using ExoticAuctionHouse_API.Repositories.Cars;
using ExoticAuctionHouse_API.Services.Auctions;
using ExoticAuctionHouse_API.Services.Cars;
using ExoticAuctionHouseModel.Informations;
using ExoticAuctionHouseModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExoticAuctionHouse_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarService _carService;
        private readonly IAuctionRepository _auctionRepository;
        private readonly ICarAttributeRepository _carAttributeRepository;

        public CarController(ICarRepository carRepository, ICarService carService, IAuctionRepository auctionRepository, ICarAttributeRepository carAttributeRepository)
        {
            _carRepository = carRepository;
            _carService = carService;
            _auctionRepository = auctionRepository;
            _carAttributeRepository = carAttributeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            var result = await _carRepository.GetCars();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(Guid id)
        {
            var result = await _carRepository.GetCarById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(AddCarInformation car)
        {
            var id = await _carService.AddCar(car);
            return new JsonResult($"Added car: {id}");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar(Car car)
        {
            await _carRepository.UpdateCar(car);
            return Ok(car);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(Guid id)
        {
            await _carRepository.DeleteCar(id);
            return Ok();
        }

        [HttpGet("NotSoldCars")]
        public async Task<IActionResult> NotSoldCars()
        {
            var cars = await _carRepository.NotSoldCars();
            return Ok(cars);
        }

        [HttpGet("PageData")]
        public async Task<IActionResult> PageData()
        {
            var pageData = await _carService.GetCarPageData();
            return Ok(pageData);
        }

        [HttpGet("GetModels/{brand}")]
        public async Task<IActionResult> GetModels(string brand)
        {
            var models = await _carRepository.GetModels(brand);
            return Ok(models);
        }

        [HttpPost("uploadImages/{id}")]
        public async Task<IActionResult> UploadImages(Guid id, List<IFormFile> files)
        {
            try
            {
                await _carService.UploadFiles(files, id.ToString());
            }
            catch (Exception)
            {
                return BadRequest("Error upload file");
            }

            return Ok();
        }

        [HttpGet("availableCars")]
        public async Task<IActionResult> AvailableCars()
        {
            var cars = await _carRepository.AvailableCars();
            return Ok(cars);
        }

        [HttpPost("sellCar")]
        public async Task<IActionResult> SellCar(SellCarInformation sellCarInformation)
        {
            var car = new Car(sellCarInformation.Car);
            var carId = await _carRepository.AddCar(car);

            sellCarInformation.Auction.CarId = carId;
            var auctionId = await _auctionRepository.Add(sellCarInformation.Auction);

            sellCarInformation.AddCarAttributeInformation.CarId = carId;
            await _carAttributeRepository.AddAtribute(sellCarInformation.AddCarAttributeInformation);

            return Ok(new CommonInformation() { CarId = carId, AuctionId = auctionId });
        }
    }
}
