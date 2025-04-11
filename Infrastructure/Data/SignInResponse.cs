namespace JWTAuthService.Infrastructure.Data;

public class SignInResponse(string accessToken, string refreshToken, string email) {
    public string AccessToken { get; set; } = accessToken;
    public string RefreshToken { get; set; } = refreshToken;
    public string Email { get; set; } = email;
}
