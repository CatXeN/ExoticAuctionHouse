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

        public async Task<CarAttribute> GetAttributes(Guid carId) => await _context.CarAttributes.FirstOrDefaultAsync(x => x.CarId == carId);

        public async Task AddAtribute(AddCarAttributeInformation attribute)
        {
            var newAttribute = new CarAttribute(attribute.AttributeId, attribute.CarId);

            await _context.AddAsync(newAttribute);
            await _context.SaveChangesAsync();
        }
    }
}
