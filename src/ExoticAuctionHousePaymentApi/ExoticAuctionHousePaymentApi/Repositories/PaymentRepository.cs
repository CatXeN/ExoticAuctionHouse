using ExoticAuctionHouseModel.Informations;
using ExoticAuctionHousePaymentApi.Data;
using ExoticAuctionHousePaymentApi.Enums;
using ExoticAuctionHousePaymentApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

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
            var existPayment = await _context.Payments.AnyAsync(x => x.TicketId == payment.TicketId && x.PaymentStatus != PaymentStatus.Canceled);

            if (existPayment)
            {
                throw new Exception("Payment reserved");
            }

            await _context.AddAsync(payment);
            await _context.SaveChangesAsync();

            return payment.Id;
        }

        public async Task<Payment> GetPayment(Guid paymentId)
        {
            var payment = await _context.Payments.FirstOrDefaultAsync(x => x.Id == paymentId)
                ?? throw new Exception("Ticket not exist");

            return payment;
        }

        public async Task CloseExpiredTickets(DateTimeOffset time)
        {
            var paymentsToClosed = _context.Payments
                .Where(x => x.LastModify.AddMinutes(30) < time 
                && (x.PaymentStatus == PaymentStatus.Created || x.PaymentStatus == PaymentStatus.Pending));

            foreach (var item in paymentsToClosed)
            {
                item.LastModify = DateTimeOffset.UtcNow;
                item.PaymentStatus = PaymentStatus.Canceled;
            }

            _context.Payments.UpdateRange(paymentsToClosed);
            await _context.SaveChangesAsync();
        }

        public async Task<Payment> Pay(PayInformation payInformation)
        {
            var ticket = await _context.Payments.FirstOrDefaultAsync(x => x.Id.Equals(payInformation.Id))
                ?? throw new Exception("Ticket not exist");

            ticket.ClientId = payInformation.ClientId;
            ticket.PaymentStatus = PaymentStatus.Paid;
            ticket.LastModify = DateTimeOffset.UtcNow;

            _context.Update(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }

        public async Task<IEnumerable<Payment>> GetClientPayments(Guid clientId)
        {
            var getClientPayments = await _context.Payments
                .Where(x => x.ClientId == clientId).ToListAsync();

            return getClientPayments;
        }
    }
}
