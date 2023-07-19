using ExoticAuctionHouse_API.Repositories;
using ExoticAuctionHouseModel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExoticAuctionHouse_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarAttributeController : ControllerBase
    {
        private readonly ICarAttributeRepository _carAttributeRepository;

        public CarAttributeController(ICarAttributeRepository carAttributeRepository)
        {
            _carAttributeRepository = carAttributeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAttributesForCar(Guid carId)
        {
            var res = await _carAttributeRepository.GetAttributes(carId);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddAttributes(List<CarAttribute> carAttributes)
        {
            await _carAttributeRepository.AddAttributes(carAttributes);
            return Ok();
        }
    }
}
