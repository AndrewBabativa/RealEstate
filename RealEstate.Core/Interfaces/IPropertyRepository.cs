using RealEstate.Core.Entities;
using RealEstate.Common.Contracts.Property.Filters;

namespace RealEstate.Core.Contracts
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<PropertyEntity>> GetAllAsync(PropertyFilter filter, CancellationToken cancellationToken = default);
        Task AddAsync(PropertyEntity property);
        Task UpdateAsync(PropertyEntity property);
        Task ChangePriceAsync(int propertyId, decimal newPrice);
        Task<PropertyEntity?> GetByIdAsync(int id);
    }
}
