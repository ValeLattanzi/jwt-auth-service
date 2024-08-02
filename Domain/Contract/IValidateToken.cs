namespace JWTAuthService.Domain.Contract;

public interface IValidateToken
{
    bool IsExpired(string token, string key);
}
