using ExoticAuctionHouseModel.Config;
using ExoticAuctionHouseModel.Informations;
using ExoticAuctionHouseModel.Models;
using ExoticAuctionHousePaymentApi.Helper;
using ExoticAuctionHousePaymentApi.Models;
using ExoticAuctionHousePaymentApi.ReadModel;
using ExoticAuctionHousePaymentApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace ExoticAuctionHousePaymentApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly ServicesConfig _servicesConfig;

    public PaymentController(IPaymentRepository paymentRepository, IOptions<ServicesConfig> config)
    {
        _paymentRepository = paymentRepository;
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

        try
        {
            var res = await _paymentRepository.CreateTicket(order);
            return Ok(res);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("clearTickets")]
    public async Task<IActionResult> CloseExperiedTickets()
    {
        await _paymentRepository.CloseExpiredTickets(DateTimeOffset.Now);
        return Ok("Tickets cleared");
    }

    [HttpPost("pay")]
    public async Task<IActionResult> Pay(PayInformation payInformation)
    {
        try
        {
            var ticket = await _paymentRepository.Pay(payInformation);

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_servicesConfig.ExoticAuctionHouseAPI);

                var soldCar = new SoldCarInformation()
                {
                    AuctionId = ticket.TicketId,
                    UserId = payInformation.ClientId
                };
                
                HttpContent body = new StringContent(JsonConvert.SerializeObject(soldCar), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("/api/auction/SoldCar", body);
            }

            return new JsonResult("Paid");
        }
        catch (Exception)
        {
            return BadRequest("Error not paid");
        }
    }

    [HttpGet("getClientPayments/{clientId}")]
    public async Task<IActionResult> GetClientPayments(Guid clientId)
    {
        var payments = await _paymentRepository.GetClientPayments(clientId);

        return Ok(payments);
    }
}