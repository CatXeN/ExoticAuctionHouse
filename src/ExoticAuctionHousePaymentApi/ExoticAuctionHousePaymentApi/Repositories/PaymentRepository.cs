using ExoticAuctionHousePaymentApi.Data;
using ExoticAuctionHousePaymentApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExoticAuctionHousePaymentApi.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DataContext _context;

        public PaymentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateTicket(Payment payment)
        {
            await _context.AddAsync(payment);
            await _context.SaveChangesAsync();

            return payment.Id;
        }

        public async Task<Payment> GetPayment(Guid paymentId)
        {
            var payment = await _context.Payments.FirstOrDefaultAsync(x => x.Id == paymentId);
            return payment;
        }
    }
}
