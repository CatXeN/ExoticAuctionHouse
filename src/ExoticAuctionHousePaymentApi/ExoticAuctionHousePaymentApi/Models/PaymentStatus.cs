namespace ExoticAuctionHousePaymentApi.Models;

public enum PaymentStatus
{
    Created = 0,
    Unpaid = 1,
    Canceled = 2,
    Pending = 3,
    Paid = 4,
    Error = 5
}