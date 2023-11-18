namespace ExoticAuctionHouse_API.Repositories.Attributes
{
    public interface IAttributeRepository
    {
        public Task<IEnumerable<ExoticAuctionHouseModel.Models.Attribute>> GetAttributes();
    }
}
