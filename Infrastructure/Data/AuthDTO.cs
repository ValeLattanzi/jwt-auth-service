namespace JWTAuthService.Infrastructure.Data;

public class AuthDTO(string accessToken, string refresjToken, string email)
{
    public string AccessToken { get; set; } = accessToken;
    public string RefresjToken { get; set; } = refresjToken;
    public string Email { get; set; } = email;
}
