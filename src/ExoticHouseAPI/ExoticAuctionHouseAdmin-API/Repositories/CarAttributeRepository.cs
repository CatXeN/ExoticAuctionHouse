using ExoticAuctionHouse_API.Data;
using ExoticAuctionHouseModel.Informations;
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

        public async Task<IEnumerable<CarAttribute>> GetAttributes(Guid carId) => await _context.CarAttributes.Where(x => x.CarId == carId).ToListAsync();

        public async Task AddAtribute(AddCarAttributeInformation attribute)
        {
            var attributes = _context.CarAttributes.Where(c => c.CarId == attribute.CarId).ToList();

            if (attributes.Any())
                _context.RemoveRange(attributes);

            var newAttribute = attribute.Attributes.Select(a => new CarAttribute()
            {
                CarId = attribute.CarId,
                AttributeId = a,
                Id = Guid.NewGuid()
            }).ToList();

            await _context.CarAttributes.AddRangeAsync(newAttribute);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CarAttribute>> GetAllAttributesWithInfo(Guid carId)
        {
            var attributes = await _context.CarAttributes.Include(a => a.Attribute).Where(x => x.CarId == carId).ToListAsync();
            return attributes;
        }
    }
}
