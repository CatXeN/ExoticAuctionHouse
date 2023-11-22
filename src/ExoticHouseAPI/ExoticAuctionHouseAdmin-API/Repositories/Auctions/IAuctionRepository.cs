using ExoticAuctionHouseModel.Informations;
using ExoticAuctionHouseModel.Models;

namespace ExoticAuctionHouse_API.Repositories.Auctions
{
    public interface IAuctionRepository
    {
        Task<IEnumerable<Auction>> Get();
        Task<IEnumerable<Auction>> GetNotEnded();
        Task<Guid> Add(AuctionInformation auction);
        Task<Auction> GetById(Guid id);
        IQueryable<Auction> GetAuctionWithCarsQuerable(string brand);
        Task End(Guid[] ids);
        Task Update(Auction auction);
        Task Update(UpdateAuctionInformation auction);
        Task<Guid> GetByCarId(Guid carId);
    }
}
