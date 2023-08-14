using ExoticAuctionHouseModel.Informations;
using ExoticAuctionHouseModel.Models;

namespace ExoticAuctionHouse_API.Repositories
{
    public interface ICarAttributeRepository
    {
        Task AddAtribute(AddCarAttributeInformation attribute);
        Task<IEnumerable<CarAttribute>> GetAttributes(Guid carId);
    }
}
