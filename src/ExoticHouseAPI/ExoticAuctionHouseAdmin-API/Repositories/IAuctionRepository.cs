using ExoticAuctionHouseModel.Informations;
using ExoticAuctionHouseModel.Models;

namespace ExoticAuctionHouse_API.Repositories
{
    public interface IAuctionRepository
    {
        Task<IEnumerable<Auction>> Get();
        Task Add(AuctionInformation auction);
        Task<Auction> GetById(Guid id);
        Task<IEnumerable<Auction>> GetCarsByFilter(SearchModel searchModel);
    }
}
