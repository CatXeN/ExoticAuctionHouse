using ExoticAuctionHouse_API.Repositories;
using ExoticAuctionHouseModel.Informations;
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

        [HttpGet("{carId}")]
        public async Task<IActionResult> GetAttributesForCar(Guid carId)
        {
            var res = await _carAttributeRepository.GetAttributes(carId);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddAttributes(AddCarAttributeInformation carAttributes)
        {
            await _carAttributeRepository.AddAtribute(carAttributes);
            return new JsonResult("Updated");
        }
    }
}
