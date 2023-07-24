using ExoticAuctionHouse_API.Data;
using ExoticAuctionHouseModel.Models;
using Microsoft.EntityFrameworkCore;

namespace ExoticAuctionHouse_API.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly DataContext _context;

        public CarRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddCar(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCar(Guid id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(car => car.Id == id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }

        public async Task<string[]> GetBrands() => await _context.Cars
            .Select(car => car.Brand)
            .Distinct()
            .ToArrayAsync();

        public async Task<Car> GetCarById(Guid id) => await _context.Cars.FirstOrDefaultAsync(car => car.Id == id);

        public async Task<IEnumerable<Car>> GetCars() => await _context.Cars.ToListAsync();

        public async Task<string[]> GetModels() => await _context.Cars
            .Select(car => car.Model)
            .Distinct()
            .ToArrayAsync();

        public async Task<IEnumerable<Car>> NotSoldCars() => await _context.Cars.Where(x => !x.IsSold).ToListAsync();

        public async Task UpdateCar(Car car)
        {
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
        }
    }
}
