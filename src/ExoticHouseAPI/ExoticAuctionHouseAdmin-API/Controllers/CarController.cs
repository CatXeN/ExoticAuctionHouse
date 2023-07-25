using ExoticAuctionHouse_API.Repositories;
using ExoticAuctionHouse_API.Services;
using ExoticAuctionHouseModel.Models;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> AddCar(Car car)
        {
            await _carRepository.AddCar(car);
            return Ok("Added car");
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
    }
}
