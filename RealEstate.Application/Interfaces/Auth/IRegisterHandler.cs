using RealEstate.Application.DTOs.Auth;

namespace RealEstate.Application.Interfaces.Auth
{
    public interface IRegisterHandler
    {
        Task<(bool Success, string Message)> Handle(RegisterDto dto);
    }
}
