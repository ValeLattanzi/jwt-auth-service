namespace JWTAuthService.Domain.Contract;

public interface IRefreshAccessToken
{
    string Refresh(string email, string accessKey);
}
