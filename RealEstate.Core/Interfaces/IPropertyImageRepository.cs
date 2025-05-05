using RealEstate.Core.Entities;

namespace RealEstate.Core.Contracts
{
    public interface IPropertyImageRepository
    {
        Task<PropertyImageEntity?> GetByIdAsync(int id);
        Task<List<PropertyImageEntity>> GetByPropertyIdAsync(int propertyId);
        Task AddAsync(PropertyImageEntity image);
        Task DeleteAsync(int id);
    }
}
