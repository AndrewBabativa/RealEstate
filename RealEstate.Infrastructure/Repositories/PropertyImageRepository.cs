using RealEstate.Core.Entities;
using RealEstate.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using RealEstate.Core.Contracts;

namespace RealEstate.Infrastructure.Repositories
{
    public class PropertyImageRepository : IPropertyImageRepository
    {
        private readonly RealEstateDbContext _context;

        public PropertyImageRepository(RealEstateDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(PropertyImageEntity propertyImage)
        {
            await _context.PropertyImages.AddAsync(propertyImage);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PropertyImageEntity> GetByIdAsync(int id)
        {
            return await _context.PropertyImages.FirstOrDefaultAsync(p => p.PropertyImageId == id);
        }

        public Task<List<PropertyImageEntity>> GetByPropertyIdAsync(int propertyId)
        {
            throw new NotImplementedException();
        }
    }
}
