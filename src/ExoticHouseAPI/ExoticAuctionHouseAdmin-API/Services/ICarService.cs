using ExoticAuctionHouseModel.Informations;

namespace ExoticAuctionHouse_API.Services
{
    public interface ICarService
    {
        Task<CarPageData> GetCarPageData();
    }
}
