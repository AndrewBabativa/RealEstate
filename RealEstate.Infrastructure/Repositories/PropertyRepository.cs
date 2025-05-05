using Microsoft.EntityFrameworkCore;
using RealEstate.Core.Contracts;
using RealEstate.Core.Entities;
using RealEstate.Infrastructure.Persistence;

namespace RealEstate.Infrastructure.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly RealEstateDbContext _context;

        public PropertyRepository(RealEstateDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PropertyEntity>> GetAllAsync(
            string? name = null,
            decimal? minPrice = null,
            decimal? maxPrice = null,
            int? year = null,
            CancellationToken cancellationToken = default)
        {
            var query = _context.Properties.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(p => p.Name.Contains(name));

            if (minPrice.HasValue)
                query = query.Where(p => p.Price >= minPrice.Value);

            if (maxPrice.HasValue)
                query = query.Where(p => p.Price <= maxPrice.Value);

            if (year.HasValue)
                query = query.Where(p => p.Year == year.Value);

            return await query.ToListAsync(cancellationToken);
        }

        public async Task AddAsync(PropertyEntity property)
        {
            _context.Properties.Add(property);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PropertyEntity property)
        {
            _context.Properties.Update(property);
            await _context.SaveChangesAsync();
        }

        public async Task ChangePriceAsync(int propertyId, decimal newPrice)
        {
            var property = await _context.Properties.FindAsync(propertyId);
            if (property != null)
            {
                property.Price = newPrice;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<PropertyEntity?> GetByIdAsync(int id)
        {
            return await _context.Properties.FindAsync(id);
        }
    }
}
