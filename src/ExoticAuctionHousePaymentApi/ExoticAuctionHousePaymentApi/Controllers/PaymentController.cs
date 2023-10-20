using ExoticAuctionHouseModel.Config;
using ExoticAuctionHouseModel.Models;
using ExoticAuctionHousePaymentApi.Helper;
using ExoticAuctionHousePaymentApi.Models;
using ExoticAuctionHousePaymentApi.ReadModel;
using ExoticAuctionHousePaymentApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ExoticAuctionHousePaymentApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IHostEnvironment _hostingEnv;
    private readonly ServicesConfig _servicesConfig;

    public PaymentController(IPaymentRepository paymentRepository, IHostEnvironment hostingEnv, IOptions<ServicesConfig> config)
    {
        _paymentRepository = paymentRepository;
        _hostingEnv = hostingEnv;
        _servicesConfig = config.Value;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPayment(Guid id)
    {
        var res = await _paymentRepository.GetPayment(id);
        return Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(PaymentInfo payment)
    {
        var auction = new Auction();
        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(_servicesConfig.ExoticAuctionHouseAPI);
            var response = await httpClient.GetAsync("/api/auction/" + payment.AuctionId);
            var responseContent = await response.Content.ReadAsStringAsync();
            auction = JsonConvert.DeserializeObject<Auction>(responseContent);
        }

        if (auction == null)
            return BadRequest("Invalid data");

        var order = OrderHelper.CreateOrder(auction, payment.ClientId);
        var res = await _paymentRepository.CreateTicket(order);

        if (_hostingEnv.IsDevelopment())
            return Redirect("http://localhost:4202/method/" + res);
        else
            return Redirect("https://payment.exoticah.pl/method/" + res);
    }
}