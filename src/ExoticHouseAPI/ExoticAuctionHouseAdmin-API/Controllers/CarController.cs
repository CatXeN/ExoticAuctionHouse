using ExoticAuctionHouse_API.Repositories.Cars;
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

        public CarController(ICarRepository carRepository, ICarService carService)
        {
            _carRepository = carRepository;
            _carService = carService;
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
    }
}
