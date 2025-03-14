using System.Security.Claims;

namespace JWTAuthService.Domain.Contract;

public interface IGenerateToken {
	string generateAccessToken(List<Claim> claims, string accessKey);
	string generateRefreshToken(List<Claim> claims, string refreshKey);
	string generateVerificationToken(Guid userId, string email);
}