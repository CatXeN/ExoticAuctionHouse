using ExoticAuctionHouse_API.Repositories;
using ExoticAuctionHouse_API.Services;
using ExoticAuctionHouseModel.Informations;
using ExoticAuctionHouseModel.Models;
using Microsoft.AspNetCore.Http;
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
        //TODO: Once the auction is over, the car from the auction should fly into the auction history
        //Support with AuctionServer
    }
}
