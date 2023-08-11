namespace ExoticAuctionHouse_API.Repositories
{
    public interface IAttributeRepository
    {
        public Task<IEnumerable<ExoticAuctionHouseModel.Models.Attribute>> GetAttributes();
    }
}
