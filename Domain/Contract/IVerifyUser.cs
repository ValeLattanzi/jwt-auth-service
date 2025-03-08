using result_pattern;

namespace JWTAuthService.Domain.Contract;

public interface IVerifyUser {
	Result VerifyByEmail(string email, string token, string verificationSecret);
}