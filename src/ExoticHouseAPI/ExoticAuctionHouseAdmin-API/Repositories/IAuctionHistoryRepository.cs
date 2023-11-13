using ExoticAuctionHouseModel.Informations;
using ExoticAuctionHouseModel.Models;

namespace ExoticAuctionHouse_API.Repositories
{
    public interface IAuctionHistoryRepository
    {
        Task<IEnumerable<AuctionHistory>> Get();
        Task<AuctionHistory> GetById(Guid id);
        Task Add(AuctionHistory[] auctionHistory);
        Task Add(AuctionHistory auctionHistory);
    }
}
