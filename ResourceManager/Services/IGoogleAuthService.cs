using Google.Apis.Auth;

namespace ResourceManager.Services;

public interface IGoogleAuthService
{
    Task<GoogleJsonWebSignature.Payload?> VerifyGoogleTokenAsync(string token); 
}