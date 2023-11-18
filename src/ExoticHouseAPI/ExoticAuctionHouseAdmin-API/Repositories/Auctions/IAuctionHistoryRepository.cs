using ExoticAuctionHouseModel.Informations;
using ExoticAuctionHouseModel.Models;

namespace ExoticAuctionHouse_API.Repositories.Auctions
{
    public interface IAuctionHistoryRepository
    {
        Task<IEnumerable<AuctionHistory>> Get();
        Task<AuctionHistory> GetById(Guid id);
        Task Add(AuctionHistory[] auctionHistory);
        Task Add(AuctionHistory auctionHistory);
        Task<IEnumerable<AuctionHistory>> MyAuctions(Guid UserId);
    }
}
