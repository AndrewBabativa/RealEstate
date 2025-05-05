using RealEstate.Common.Contracts.Auth.Request;
using RealEstate.Common.Contracts.Auth.Responses;
using RealEstate.Common.Contracts.PropertyImage.Request;

namespace RealEstate.Core.Contracts
{
    public interface IAuthService
    {
        Task<(bool Success, string Message)> RegisterAsync(RegisterAuthRequest request);
        Task<AuthResponse?> LoginAsync(LoginAuthRequest request);
    }
}
