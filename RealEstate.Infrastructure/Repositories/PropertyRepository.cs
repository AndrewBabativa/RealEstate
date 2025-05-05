using RealEstate.Core.Entities;
using RealEstate.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using RealEstate.Core.Contracts;
using RealEstate.Common.Contracts.Property.Filters;

namespace RealEstate.Infrastructure.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly RealEstateDbContext _context;

        public PropertyRepository(RealEstateDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PropertyEntity>> GetAllAsync(PropertyFilter filter, CancellationToken cancellationToken)
        {
            var query = _context.Properties
                .Include(p => p.Images)
                .Include(p => p.Owner)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Name))
                query = query.Where(p => p.Name.Contains(filter.Name));

            if (filter.MinPrice.HasValue)
                query = query.Where(p => p.Price >= filter.MinPrice.Value);

            if (filter.MaxPrice.HasValue)
                query = query.Where(p => p.Price <= filter.MaxPrice.Value);

            if (filter.Year.HasValue)
                query = query.Where(p => p.Year == filter.Year.Value);

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<PropertyEntity?> GetByIdAsync(int id)
        {
            return await _context.Properties
                .Include(p => p.Owner)
                .Include(p => p.Images)
                .Include(p => p.Traces)
                .FirstOrDefaultAsync(p => p.PropertyId == id);
        }

        public async Task AddAsync(PropertyEntity property)
        {
            await _context.Properties.AddAsync(property);
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
            property.Price = newPrice;
            await _context.SaveChangesAsync();
        }

    }
}
