using ExoticAuctionHouse_API.Repositories;
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

        public AuctionController(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetExhibitedCars()
        {
            var cars = await _auctionRepository.Get();
            return Ok(cars);
        }

        [HttpPost]
        public async Task<IActionResult> AddCarToAuction(Auction auction)
        {
            await _auctionRepository.Add(auction);
            return Ok("Added car on auction");
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

        //TODO: Once the auction is over, the car from the auction should fly into the auction history
        //Support with AuctionServer
    }
}
