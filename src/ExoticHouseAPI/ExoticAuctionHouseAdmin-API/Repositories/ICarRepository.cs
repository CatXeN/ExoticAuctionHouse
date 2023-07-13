using ExoticAuctionHouseModel.Models;

namespace ExoticAuctionHouse_API.Repositories
{
    public interface ICarRepository
    {
        Task<Car> GetCarById(Guid id);
        Task<IEnumerable<Car>> GetCars();
        Task AddCar(Car car);
        Task DeleteCar(Guid id);
        Task UpdateCar(Car car);
        Task<IEnumerable<Car>> NotSoldCars();
    }
}
