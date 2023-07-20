using ExoticAuctionHouseModel.Models;

namespace ExoticAuctionHouse_API.Repositories
{
    public interface IAuctionRepository
    {
        Task<IEnumerable<Auction>> Get();
        Task Add(Auction auction);
        Task<Auction> GetById(Guid id);
    }
}
