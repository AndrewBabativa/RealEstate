using Microsoft.EntityFrameworkCore;
using RealEstate.Common.Contracts.PropertyImage.Request;
using RealEstate.Core.Contracts;
using RealEstate.Core.Entities;
using RealEstate.Core.ValueObjects;
using RealEstate.Infrastructure.Persistence;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly RealEstateDbContext _context;

        public AuthService(RealEstateDbContext context)
        {
            _context = context;
        }

        public async Task<(bool Success, string Message)> RegisterAsync(UserEntity user)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == user.Username);

            if (existingUser != null)
                return (false, "User already exists");

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return (true, "User registered successfully");
        }

        public async Task<UserEntity?> LoginAsync(AuthCredentials credentials)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == credentials.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(credentials.Password, user.PasswordHash))
                return null;

            return user;
        }
    }
}
