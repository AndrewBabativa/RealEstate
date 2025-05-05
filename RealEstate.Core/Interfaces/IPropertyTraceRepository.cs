using RealEstate.Core.Entities;

namespace RealEstate.Core.Contracts
{
    public interface IPropertyTraceRepository
    {
        Task<int> CreateAsync(PropertyTraceEntity trace);
        Task<IEnumerable<PropertyTraceEntity>> GetByPropertyIdAsync(int propertyId);
    }
}
