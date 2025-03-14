using JWTAuthService.Domain.Contract;
using System.Security.Claims;

namespace JWTAuthService.Domain.UseCase;

public class RefreshAccessToken : IRefreshAccessToken {
	private readonly IGenerateToken _generateToken;

	public RefreshAccessToken(IGenerateToken generateToken) {
		_generateToken = generateToken;
	}

	public string Refresh(List<Claim> claims, string accessKey) {
		return _generateToken.generateAccessToken(claims, accessKey);
	}
}