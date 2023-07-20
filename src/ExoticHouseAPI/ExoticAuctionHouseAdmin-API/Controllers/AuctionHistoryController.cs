using ExoticAuctionHouse_API.Repositories;
using ExoticAuctionHouseModel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExoticAuctionHouse_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionHistoryController : ControllerBase
    {
        private readonly IAuctionHistoryRepository _auctionHistoryRepository;

        public AuctionHistoryController(IAuctionHistoryRepository auctionHistoryRepository)
        {
            _auctionHistoryRepository = auctionHistoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var histories = await _auctionHistoryRepository.Get();
            return Ok(histories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var history = await _auctionHistoryRepository.GetById(id);
                return Ok(history);
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(AuctionHistory auctionHistory)
        {
            await _auctionHistoryRepository.Add(auctionHistory);
            return Ok("Added auction history");
        }
    }
}
