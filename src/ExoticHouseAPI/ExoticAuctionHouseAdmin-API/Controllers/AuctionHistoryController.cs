using ExoticAuctionHouse_API.Repositories.Auctions;
using ExoticAuctionHouse_API.Services.Auctions;
using ExoticAuctionHouseModel.Informations;
using Microsoft.AspNetCore.Mvc;

namespace ExoticAuctionHouse_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionHistoryController : ControllerBase
    {
        private readonly IAuctionHistoryRepository _auctionHistoryRepository;
        private readonly IAuctionService _auctionService;

        public AuctionHistoryController(IAuctionHistoryRepository auctionHistoryRepository, IAuctionService service)
        {
            _auctionHistoryRepository = auctionHistoryRepository;
            _auctionService = service;
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
        public async Task<IActionResult> Add(AuctionHistoryInformation[] auctionHistory)
        {
            try
            {
                await _auctionService.EndAuctions(auctionHistory);
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }
            
            return Ok("Added auction history");
        }

        [HttpGet("myAuctions/{userId}")]
        public async Task<IActionResult> MyAuction(Guid userId)
        {
            var myAuctions = await _auctionHistoryRepository.MyAuctions(userId);
            return Ok(myAuctions);
        }
    }
}
