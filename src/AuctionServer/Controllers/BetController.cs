using AuctionServer.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuctionServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetController : ControllerBase
    {
        private DataContext _context;

        public BetController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurrentPrice(Guid id)
        {
            var auction = await _context.Bets.FirstOrDefaultAsync(x => x.AuctionId == id);

            if (auction == null)
            {
                return NotFound();
            }

            return Ok(auction);
        }
    }
}
