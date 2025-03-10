using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JWTAuthService.Domain.Contract;
using JWTAuthService.Errors;
using Microsoft.IdentityModel.Tokens;
using result_pattern;

namespace JWTAuthService.Domain.UseCase;

public class VerifyUser : IVerifyUser {
	private readonly IValidateToken _validateToken;

	public VerifyUser(IValidateToken validateToken) {
		_validateToken = validateToken;
	}

	public Result VerifyByEmail(string email, string token, string verificationSecret) {
		// 1. Validate if token is expired
		var tokenWasExpired = _validateToken.IsExpired(token, verificationSecret);
		if (tokenWasExpired)
			return Result.failure(AuthErrors.TokenExpired);

		// 2. Create validation claims
		var claimsToValidate = new List<Claim> {
			new(ClaimTypes.Email, email)
		};

		return _validateToken.ValidateClaims(token, claimsToValidate);
	}
}