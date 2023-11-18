using ExoticAuctionHouseModel.Informations;
using ExoticAuctionHousePaymentApi.Models;

namespace ExoticAuctionHousePaymentApi.Repositories;

public interface IPaymentRepository
{
    Task<Guid> CreateTicket(Payment payment);
    Task<Payment> GetPayment(Guid paymentId);
    Task CloseExpiredTickets(DateTimeOffset time);
    Task<Payment> Pay(PayInformation payInformation);
    Task<IEnumerable<Payment>> GetClientPayments(Guid clientId);
}