using JWTAuthService.Entity.Class;
using result_pattern;

namespace JWTAuthService.Domain.Contract;

public interface ISendVerificationEmail {
	Task<Result> SendEmail(User user, SmptConfiguration smptConfiguration, string appName, Uri frontEndUrl,
		Uri appLogoUrl);
}