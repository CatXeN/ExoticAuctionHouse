using ExoticAuctionHouse_API.Data;
using ExoticAuctionHouseModel.Informations;
using ExoticAuctionHouseModel.Models;
using Microsoft.EntityFrameworkCore;

namespace ExoticAuctionHouse_API.Repositories.Cars
{
    public class CarRepository : ICarRepository
    {
        private readonly DataContext _context;

        public CarRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddCar(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return car.Id;
        }

        public async Task<IEnumerable<Car>> AvailableCars()
        {
            var exhabitedCarsId = _context.Auctions
                .Where(x => !x.IsEnd)
                .Select(x => x.CarId);

            var notSoldCars = _context.Cars
                .Where(x => !x.IsSold && !exhabitedCarsId.Contains(x.Id));

            return await notSoldCars.ToListAsync();
        }

        public async Task<bool> ClientFollowingCar(Guid clientId, Guid carId)
        {
            return await _context.FollowedCars.AnyAsync(x => x.ClientId == clientId && carId == x.CarId);
        }

        public async Task DeleteCar(Guid id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(car => car.Id == id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }

        public async Task FollwingCar(FollowingCar followingCar)
        {
            var isFollowing = await _context.FollowedCars.FirstOrDefaultAsync(x => x.CarId == followingCar.CarId && x.ClientId == followingCar.ClientId);

            if (isFollowing == null)
            {
                var followedCar = new FollowedCar(followingCar.ClientId, followingCar.CarId);
                await _context.AddAsync(followedCar);
            }
            else
            {
                _context.FollowedCars.Remove(isFollowing);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<string[]> GetBrands() => await _context.Cars
            .Select(car => car.Brand)
            .Distinct()
            .ToArrayAsync();

        public async Task<Car> GetCarById(Guid id) => await _context.Cars.FirstOrDefaultAsync(car => car.Id == id);

        public async Task<IEnumerable<Car>> GetCars() => await _context.Cars.ToListAsync();

        public IQueryable<Car> GetCarsQueryable(string brand) => _context.Cars
            .Where(car => car.Brand == brand)
            .AsQueryable();

        public async Task<List<FollowedCar>> GetFollowingCars(Guid clientId) =>
            await _context.FollowedCars
            .Include(x => x.Car)
            .Where(x => x.ClientId == clientId)
            .ToListAsync();

        public async Task<string[]> GetModels(string brand) => await _context.Cars
            .Where(car  => car.Brand == brand)
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
