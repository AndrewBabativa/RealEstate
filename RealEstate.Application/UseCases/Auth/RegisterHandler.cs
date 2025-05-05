using RealEstate.Common.Contracts.PropertyImage.Request;
using RealEstate.Core.Contracts;
using RealEstate.Core.Entities;
using BCrypt.Net;

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
            var user = new UserEntity
            {
                Username = request.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            return await _authService.RegisterAsync(user);
        }
    }

}
