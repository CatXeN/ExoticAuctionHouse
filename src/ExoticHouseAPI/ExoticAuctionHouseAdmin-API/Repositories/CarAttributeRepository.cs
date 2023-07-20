using ExoticAuctionHouse_API.Data;
using ExoticAuctionHouseModel.Models;
using Microsoft.EntityFrameworkCore;

namespace ExoticAuctionHouse_API.Repositories
{
    public class CarAttributeRepository : ICarAttributeRepository
    {
        private readonly DataContext _context;

        public CarAttributeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAttributes(List<CarAttribute> attributes)
        {
            await _context.AddAsync(attributes);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CarAttribute>> GetAttributes(Guid carId) => await _context.CarAttributes.Where(x => x.CarId == carId).ToListAsync();

        public async Task UpdateAttribute(CarAttribute attribute)
        {
            throw new NotImplementedException();
        }
    }
}
