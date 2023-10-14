using ExoticAuctionHouseModel.Models;
using ExoticAuctionHousePaymentApi.Models;

namespace ExoticAuctionHousePaymentApi.Helper
{
    public static class OrderHelper
    {
        public static Payment CreateOrder(Auction auction, Guid userId)
        {
            var payment = new Payment
            {
                Amount = auction.CurrentPrice,
                CreatedAt = DateTime.Now,
                ClientId = userId,
                LastModify = DateTime.Now,
                PaymentStatus = Enums.PaymentStatus.Created,
                TicketId = auction.Id
            };

            return payment;
        }
    }
}
