using RealEstate.Core.Entities;

namespace RealEstate.Core.Contracts
{
    public interface IOwnerRepository
    {
        Task<OwnerEntity?> GetByIdAsync(int id);
        Task<List<OwnerEntity>> GetAllAsync();
        Task AddAsync(OwnerEntity owner);
        Task UpdateAsync(OwnerEntity owner);
        Task DeleteAsync(int id);
    }
}
