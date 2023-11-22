using ExoticAuctionHouse_API.Repositories.Auctions;
using ExoticAuctionHouse_API.Services.Auctions;
using ExoticAuctionHouseModel.Informations;
using Microsoft.AspNetCore.Mvc;

namespace ExoticAuctionHouse_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IAuctionService _auctionService;

        public AuctionController(IAuctionRepository auctionRepository, IAuctionService auctionService)
        {
            _auctionRepository = auctionRepository;
            _auctionService = auctionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetExhibitedCars()
        {
            var cars = await _auctionRepository.GetNotEnded();
            return Ok(cars);
        }

        [HttpGet("allAuctions")]
        public async Task<IActionResult> GetAuctionsWithEnds()
        {
            var cars = await _auctionRepository.Get();
            return Ok(cars);
        }

        [HttpPost]
        public async Task<IActionResult> AddCarToAuction(AuctionInformation auction)
        {
            await _auctionRepository.Add(auction);
            return new JsonResult("Added car on auction");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuction(UpdateAuctionInformation auction)
        {
            await _auctionRepository.Update(auction);
            return new JsonResult("Updated auction");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var auction = await _auctionRepository.GetById(id);
                return Ok(auction);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Search")]
        public async Task<IActionResult> GetCarsByFilter(SearchModel searchModel)
        {
            var cars = await _auctionService.GetCarsByFilter(searchModel);
            return Ok(cars);
        }

        [HttpPost("SoldCar")]
        public async Task<IActionResult> SoldCar(SoldCarInformation soldCarInformation)
        {
            await _auctionService.SoldCar(soldCarInformation);
            return Ok();
        }

        [HttpGet("GetAuctionId/{carId}")]
        public  async Task<IActionResult> GetAuctionIdByCarId(Guid carId)
        {
            var auctionId = await _auctionRepository.GetByCarId(carId);
            return Ok(auctionId);
        }
    }
}
