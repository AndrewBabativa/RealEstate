using RealEstate.Application.DTOs.Auth;
using RealEstate.Application.Interfaces.Auth;
using RealEstate.Core.Entities;

namespace RealEstate.Application.UseCases.Auth
{
    public class RegisterHandler : IRegisterHandler
    {
        private readonly IAuthService _authService;

        public RegisterHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<(bool Success, string Message)> Handle(RegisterDto dto)
        {
            var user = new UserEntity
            {
                Username = dto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            return await _authService.RegisterAsync(user);
        }
    }
}
