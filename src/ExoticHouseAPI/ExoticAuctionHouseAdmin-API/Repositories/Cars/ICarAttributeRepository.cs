using ExoticAuctionHouseModel.Informations;
using ExoticAuctionHouseModel.Models;

namespace ExoticAuctionHouse_API.Repositories.Cars
{
    public interface ICarAttributeRepository
    {
        Task AddAtribute(AddCarAttributeInformation attribute);
        Task<IEnumerable<CarAttribute>> GetAttributes(Guid carId);
        Task<IEnumerable<CarAttribute>> GetAllAttributesWithInfo(Guid carId);
    }
}
