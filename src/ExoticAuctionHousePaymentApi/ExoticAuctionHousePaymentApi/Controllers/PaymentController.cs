using Microsoft.AspNetCore.Mvc;

namespace ExoticAuctionHousePaymentApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPayment()
    {
        return Ok("Hello world");
    }
}