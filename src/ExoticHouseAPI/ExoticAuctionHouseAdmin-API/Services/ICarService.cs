using ExoticAuctionHouseModel.Informations;
using ExoticAuctionHouseModel.Models;

namespace ExoticAuctionHouse_API.Services
{
    public interface ICarService
    {
        Task<CarPageData> GetCarPageData();
        Task<Guid> AddCar(AddCarInformation addCarInformation);
        Task<List<TranslatedAttribute>> GetTranslatedAttribute(Guid carId);
    }
}
