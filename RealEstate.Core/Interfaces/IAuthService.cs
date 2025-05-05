using RealEstate.Core.Entities;
using RealEstate.Core.ValueObjects;

public interface IAuthService
{
    Task<(bool Success, string Message)> RegisterAsync(UserEntity user);
    Task<UserEntity?> LoginAsync(AuthCredentials credentials);
}
