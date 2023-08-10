using ExoticAuctionHouseModel.Informations;
using ExoticAuctionHouseModel.Models;

namespace ExoticAuctionHouse_API.Repositories
{
    public interface ICarAttributeRepository
    {
        Task UpdateAttribute(AddCarAttributeInformation attribute);
        Task<CarAttribute> GetAttributes(Guid carId);
    }
}
