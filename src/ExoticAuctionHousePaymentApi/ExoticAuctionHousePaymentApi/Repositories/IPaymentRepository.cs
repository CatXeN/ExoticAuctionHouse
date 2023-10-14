using ExoticAuctionHousePaymentApi.Models;

namespace ExoticAuctionHousePaymentApi.Repositories;

public interface IPaymentRepository
{
    Task<Guid> CreateTicket(Payment payment);
    Task<Payment> GetPayment(Guid paymentId);
}