using ExoticAuctionHouseModel.Informations;
using ExoticAuctionHouseModel.Models;

namespace ExoticAuctionHouse_API.Repositories
{
    public interface IAuctionRepository
    {
        Task<IEnumerable<Auction>> Get();
        Task<IEnumerable<Auction>> GetNotEnded();
        Task Add(AuctionInformation auction);
        Task<Auction> GetById(Guid id);
        IQueryable<Auction> GetAuctionWithCarsQuerable(string brand);
        Task End(Guid[] ids);
        Task Update(UpdateAuctionInformation auction);
    }
}
