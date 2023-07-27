using ExoticAuctionHouseModel.Informations;
using ExoticAuctionHouseModel.Models;

namespace ExoticAuctionHouse_API.Services
{
    public interface IAuctionService
    {
        Task<IEnumerable<Auction>> GetCarsByFilter(SearchModel searchModel);
    }
}
