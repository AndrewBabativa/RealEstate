using RealEstate.Core.Entities;

namespace RealEstate.Core.Contracts
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<PropertyEntity>> GetAllAsync(  string? name = null,
                                                        decimal? minPrice = null,
                                                        decimal? maxPrice = null,
                                                        int? year = null,
                                                        CancellationToken cancellationToken = default);

        Task AddAsync(PropertyEntity property);
        Task UpdateAsync(PropertyEntity property);
        Task ChangePriceAsync(int propertyId, decimal newPrice);
        Task<PropertyEntity?> GetByIdAsync(int id);
    }
}
