using RealEstate.Core.Entities;
using RealEstate.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using RealEstate.Core.Contracts;

namespace RealEstate.Infrastructure.Repositories
{
    public class PropertyTraceRepository : IPropertyTraceRepository
    {
        private readonly RealEstateDbContext _context;

        public PropertyTraceRepository(RealEstateDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(PropertyTraceEntity trace)
        {
            _context.PropertyTraces.Add(trace);
            await _context.SaveChangesAsync();
            return trace.PropertyTraceId;
        }

        public async Task<IEnumerable<PropertyTraceEntity>> GetByPropertyIdAsync(int propertyId)
        {
            return await _context.PropertyTraces
                .Where(t => t.PropertyId == propertyId)
                .ToListAsync();
        }
    }

}
