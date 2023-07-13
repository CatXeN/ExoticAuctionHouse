using ExoticAuctionHouse_API.Repositories;
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

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
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
    }
}
