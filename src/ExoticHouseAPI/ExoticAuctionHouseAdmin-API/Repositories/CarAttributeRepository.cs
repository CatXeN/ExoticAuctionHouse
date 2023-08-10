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

        public async Task UpdateAttribute(AddCarAttributeInformation attribute)
        {
            var carAttribute = await _context.CarAttributes.FirstOrDefaultAsync(ca => ca.CarId == attribute.CarId);

            if (carAttribute == null) 
            {
                var ca = new CarAttribute()
                {
                    CarId = attribute.CarId,
                    Attributes = attribute.Attributes,
                    Id = Guid.NewGuid()
                };

                await _context.CarAttributes.AddAsync(ca);
                await _context.SaveChangesAsync();
            }
            else
            {
                carAttribute.Attributes = attribute.Attributes;

                _context.Update(carAttribute);
                await _context.SaveChangesAsync();
            }
        }
    }
}
