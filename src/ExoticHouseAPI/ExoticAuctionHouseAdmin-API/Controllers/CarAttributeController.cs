using ExoticAuctionHouse_API.Repositories.Cars;
using ExoticAuctionHouse_API.Services.Cars;
using ExoticAuctionHouseModel.Informations;
using Microsoft.AspNetCore.Mvc;

namespace ExoticAuctionHouse_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarAttributeController : ControllerBase
    {
        private readonly ICarAttributeRepository _carAttributeRepository;
        private readonly ICarService _carService;

        public CarAttributeController(ICarAttributeRepository carAttributeRepository, ICarService carService)
        {
            _carAttributeRepository = carAttributeRepository;
            _carService = carService;
        }

        [HttpGet("{carId}")]
        public async Task<IActionResult> GetAttributesForCar(Guid carId)
        {
            var res = await _carAttributeRepository.GetAttributes(carId);
            return Ok(res);
        }

        [HttpGet("translated/{carId}")]
        public async Task<IActionResult> GetTranslatedAttributesForCar(Guid carId)
        {
            var res = await _carService.GetTranslatedAttribute(carId);
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
