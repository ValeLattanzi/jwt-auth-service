namespace JWTAuthService.Infrastructure.Data;

public class AuthDTO(string accessToken, string refreshToken, string email)
{
    public string AccessToken { get; set; } = accessToken;
    public string RefreshToken { get; set; } = refreshToken;
    public string Email { get; set; } = email;
}

public class LoginDTO(string email, string password)
{
    public string Email { get; set; } = email;
    public string Password { get; set; } = password;
}