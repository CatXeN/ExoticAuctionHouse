using ExoticAuctionHouseModel.Models;

namespace ExoticAuctionHouse_API.Repositories.Cars
{
    public interface ICarRepository
    {
        Task<Car> GetCarById(Guid id);
        Task<IEnumerable<Car>> GetCars();
        Task<Guid> AddCar(Car car);
        Task DeleteCar(Guid id);
        Task UpdateCar(Car car);
        Task<IEnumerable<Car>> NotSoldCars();
        Task<string[]> GetBrands();
        Task<string[]> GetModels(string brand);
        IQueryable<Car> GetCarsQueryable(string brand);
        Task<IEnumerable<Car>> AvailableCars();
    }
}
