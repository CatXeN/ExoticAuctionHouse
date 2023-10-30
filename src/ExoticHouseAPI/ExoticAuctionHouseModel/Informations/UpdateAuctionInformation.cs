namespace ExoticAuctionHouseModel.Informations
{
    public class UpdateAuctionInformation
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime BiddingBegins { get; set; }
        public decimal AmountStarting { get; set; }
        public decimal CurrentPrice { get; set; }
        public string Location { get; set; }
        public bool IsEnd { get; set; }
    }
}
