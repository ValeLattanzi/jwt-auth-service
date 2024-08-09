using System.Security.Claims;

namespace JWTAuthService.Domain.Contract;

public interface IRefreshAccessToken
{
    string Refresh(List<Claim> claims, string accessKey);
}
