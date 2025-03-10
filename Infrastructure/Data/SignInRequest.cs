namespace JWTAuthService.Infrastructure.Data;

public class SignInRequest(string email, string password)
{
    public string Email { get; set; } = email;
    public string Password { get; set; } = password;
}