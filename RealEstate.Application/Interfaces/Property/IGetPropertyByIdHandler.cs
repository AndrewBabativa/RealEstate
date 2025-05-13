using RealEstate.Application.DTOs.Property;

namespace RealEstate.Application.Interfaces.Property
{
    public interface IGetPropertyByIdHandler
    {
        Task<PropertyDto> Handle(int id, CancellationToken cancellationToken = default);
    }
}
