using RealEstate.Application.DTOs.Property;

namespace RealEstate.Application.Interfaces.Property
{
    public interface ICreatePropertyHandler
    {
        Task<PropertyDto> Handle(CreatePropertyDto dto, CancellationToken cancellationToken);
    }
}
