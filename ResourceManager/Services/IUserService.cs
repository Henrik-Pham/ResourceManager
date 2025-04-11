using ResourceManager.DTO;
using ResourceManager.Models;

namespace ResourceManager.Services;

public interface IUserService
{
    Task<User?> RegisterAsync(RegisterDto registerDto);
    Task<TokenDto?> LoginAsync(LoginDto loginDto);
    Task<TokenDto?> RefreshTokenAsync(string refreshToken);
    Task RevokeTokenAsync(string username);
    Task<bool> ResetPasswordAsync(string email);
}