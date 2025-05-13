using RealEstate.Application.DTOs.Property;

namespace RealEstate.Application.Interfaces.Property
{
    public interface IUpdatePropertyHandler
    {
        Task<PropertyDto> Handle(UpdatePropertyDto request, CancellationToken cancellationToken);
    }
}
