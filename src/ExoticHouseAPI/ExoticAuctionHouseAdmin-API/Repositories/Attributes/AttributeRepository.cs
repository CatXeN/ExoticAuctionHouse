using ExoticAuctionHouse_API.Data;
using Microsoft.EntityFrameworkCore;

namespace ExoticAuctionHouse_API.Repositories.Attributes
{
    public class AttributeRepository : IAttributeRepository
    {
        private readonly DataContext _context;

        public AttributeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExoticAuctionHouseModel.Models.Attribute>> GetAttributes()
        {
            return await _context.Attributes.ToListAsync();
        }
    }
}
