using RealEstate.Common.Contracts.PropertyImage.Request;
using RealEstate.Core.Contracts;

namespace RealEstate.Application.UseCases.Auth
{
    public class RegisterHandler
    {
        private readonly IAuthService _authService;

        public RegisterHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<(bool Success, string Message)> Handle(RegisterAuthRequest request)
        {
            return await _authService.RegisterAsync(request);
        }
    }
}
