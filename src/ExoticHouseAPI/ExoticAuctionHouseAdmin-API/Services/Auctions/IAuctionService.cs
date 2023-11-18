using ExoticAuctionHouseModel.Informations;
using ExoticAuctionHouseModel.Models;

namespace ExoticAuctionHouse_API.Services.Auctions
{
    public interface IAuctionService
    {
        Task<IEnumerable<Auction>> GetCarsByFilter(SearchModel searchModel);
        Task EndAuctions(AuctionHistoryInformation[] auctionHistoryInformation);
        Task SoldCar(SoldCarInformation soldCarInformation);
    }
}
