using RealEstate.Common.Contracts.Auth.Request;
using RealEstate.Common.Contracts.Auth.Responses;
using RealEstate.Core.Contracts;

namespace RealEstate.Application.UseCases.Auth
{
    public class LoginHandler
    {
        private readonly IAuthService _authService;

        public LoginHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<AuthResponse?> Handle(LoginAuthRequest request)
        {
            return await _authService.LoginAsync(request);
        }
    }
}
