namespace JWTAuthService.Domain.Contract;

public interface IGenerateToken
{
    string GenerateAccessToken(string email, string accessKey);
    string GenerateRefreshToken(string email, string refreshKey);
}
