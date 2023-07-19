using ExoticAuctionHouseModel.Models;

namespace ExoticAuctionHouse_API.Repositories
{
    public interface ICarAttributeRepository
    {
        Task AddAttributes(List<CarAttribute> attributes);
        Task UpdateAttribute(CarAttribute attribute);
        Task<IEnumerable<CarAttribute>> GetAttributes(Guid carId);
    }
}
