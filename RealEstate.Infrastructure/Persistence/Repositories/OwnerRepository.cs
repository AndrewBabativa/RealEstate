using RealEstate.Core.Entities;
using Microsoft.EntityFrameworkCore;
using RealEstate.Core.Contracts;

namespace RealEstate.Infrastructure.Persistence.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly RealEstateDbContext _context;

        public OwnerRepository(RealEstateDbContext context)
        {
            _context = context;
        }

        public async Task<OwnerEntity?> GetByIdAsync(int id)
        {
            return await _context.Owners.FindAsync(id);
        }

        public async Task<List<OwnerEntity>> GetAllAsync()
        {
            return await _context.Owners.ToListAsync();
        }

        public async Task AddAsync(OwnerEntity owner)
        {
            await _context.Owners.AddAsync(owner);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OwnerEntity owner)
        {
            _context.Owners.Update(owner);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var owner = await _context.Owners.FindAsync(id);
            if (owner != null)
            {
                _context.Owners.Remove(owner);
                await _context.SaveChangesAsync();
            }
        }
    }
}
