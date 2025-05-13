using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RealEstate.Application.DTOs.Auth;
using RealEstate.Application.Interfaces.Auth;
using RealEstate.Core.ValueObjects;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RealEstate.Application.UseCases.Auth
{
    public class LoginHandler : ILoginHandler
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public LoginHandler(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
        }

        public async Task<AuthResultDto?> Handle(LoginDto dto)
        {
            var credentials = new AuthCredentials(dto.Username, dto.Password);
            var user = await _authService.LoginAsync(credentials);

            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Audience = _configuration["JwtSettings:Audience"],
                Issuer = _configuration["JwtSettings:Issuer"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthResultDto
            {
                Username = user.Username,
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
