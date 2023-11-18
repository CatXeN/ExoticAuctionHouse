using ExoticAuctionHouse_API.Repositories.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace ExoticAuctionHouse_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttributeController : ControllerBase
    {
        private readonly IAttributeRepository _attributeRepository;

        public AttributeController(IAttributeRepository attributeRepository)
        {
            _attributeRepository = attributeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAttributes()
        {
            var attributes = await _attributeRepository.GetAttributes();
            return Ok(attributes);
        }
    }
}
