using System.Security.Claims;
using result_pattern;

namespace JWTAuthService.Domain.Contract;

public interface IValidateToken {
	bool IsExpired(string token, string key);
	Result ValidateClaims(string token, List<Claim> claims);
}