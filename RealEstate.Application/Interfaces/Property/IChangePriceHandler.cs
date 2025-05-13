using RealEstate.Application.DTOs.Property;

namespace RealEstate.Application.Interfaces.Property
{
    public interface IChangePriceHandler
    {
        Task<PropertyDto> Handle(ChangePriceDto dto, CancellationToken cancellationToken);
    }
}
