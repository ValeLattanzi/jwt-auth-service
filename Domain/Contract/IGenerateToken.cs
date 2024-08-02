namespace JWTAuthService.Domain.Contract;

public interface IGenerateToken
{
    string GenerarAccessToken(string email, string accessKey);
    string GenerarRefreshToken(string email, string refreshKey);
}
