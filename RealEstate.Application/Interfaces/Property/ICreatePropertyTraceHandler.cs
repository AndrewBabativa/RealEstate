using RealEstate.Application.DTOs.PropertyTrace;

namespace RealEstate.Application.Interfaces.Property
{
    public interface ICreatePropertyTraceHandler
    {
        Task<int> Handle(CreatePropertyTraceDto dto);
    }
}
