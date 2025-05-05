using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RealEstate.Common.Contracts.Auth.Request;
using RealEstate.Common.Contracts.Auth.Responses;
using RealEstate.Common.Contracts.PropertyImage.Request;
using RealEstate.Core.Contracts;
using RealEstate.Core.Entities;
using RealEstate.Infrastructure.Persistence;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RealEstate.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly RealEstateDbContext _context; 
        private readonly IConfiguration _configuration;

        public AuthService(RealEstateDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<(bool Success, string Message)> RegisterAsync(RegisterAuthRequest request)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == request.Username);

            if (existingUser != null)
                return (false, "User already exists");

            var user = new UserEntity
            {
                Username = request.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return (true, "User registered successfully");
        }

        public async Task<AuthResponse?> LoginAsync(LoginAuthRequest request)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == request.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
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
            return new AuthResponse
            {
                Username = user.Username,
                Token = tokenHandler.WriteToken(token)
            };
        }

    }
}
