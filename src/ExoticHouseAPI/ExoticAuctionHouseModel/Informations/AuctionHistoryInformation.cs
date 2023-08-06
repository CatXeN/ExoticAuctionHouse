namespace ExoticAuctionHouseModel.Informations
{
    public class AuctionHistoryInformation
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public DateTimeOffset SoldAt { get; set; }
        public decimal Price { get; set; }
        public bool IsSold { get; set; }
        public Guid? UserId { get; set; }
    }
}
