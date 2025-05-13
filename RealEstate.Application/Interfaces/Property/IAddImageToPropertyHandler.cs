using RealEstate.Application.DTOs.PropertyImage;

namespace RealEstate.Application.Interfaces.Property
{
    public interface IAddImageToPropertyHandler
    {
        Task Handle(PropertyImageDto request);
    }
}
