using JWTAuthService.Domain.Contract;

namespace JWTAuthService.Domain.UseCase;

public class RefreshAccessToken : IRefreshAccessToken
{
    private readonly IGenerateToken _generateToken;

    public RefreshAccessToken(IGenerateToken generateToken)
    {
        _generateToken = generateToken;
    }

    public string Refresh(string email, string accessKey)
    {
        return _generateToken.GenerarAccessToken(email, accessKey);
    }
}
