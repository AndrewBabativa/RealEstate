using RealEstate.Application.DTOs.Property;

namespace RealEstate.Application.Interfaces.Property
{
    public interface IListPropertiesHandler
    {
        Task<IEnumerable<PropertyDto>> Handle(PropertyFilterDto filter, CancellationToken cancellationToken);

    }
}
