namespace ExoticAuctionHousePaymentApi.Models;

public class Payment
{
    public Guid Id { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public decimal Amount { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset LastModify { get; set; }
    public Guid ClientId { get; set; }
    public Guid TicketId { get; set; } //AuctionId
}