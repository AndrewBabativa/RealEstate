using RealEstate.Application.DTOs.Auth;

namespace RealEstate.Application.Interfaces.Auth
{
    public interface ILoginHandler
    {
        Task<AuthResultDto?> Handle(LoginDto dto);
    }
}
