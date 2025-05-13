using RealEstate.Application.DTOs.Owner;

namespace RealEstate.Application.Interfaces.Owner
{
    public interface ICreateOwnerHandler
    {
        Task<OwnerDto> Handle(CreateOwnerDto ownerDto, CancellationToken cancellationToken);
    }
}
