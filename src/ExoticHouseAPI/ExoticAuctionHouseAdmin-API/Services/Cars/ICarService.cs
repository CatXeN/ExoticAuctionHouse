using ExoticAuctionHouseModel.Informations;
using ExoticAuctionHouseModel.Models;

namespace ExoticAuctionHouse_API.Services.Cars
{
    public interface ICarService
    {
        Task<CarPageData> GetCarPageData();
        Task<Guid> AddCar(AddCarInformation addCarInformation);
        Task<List<TranslatedAttribute>> GetTranslatedAttribute(Guid carId);
        Task<List<string>> UploadFiles(List<IFormFile> files, string id);
    }
}
