using result_pattern;

namespace JWTAuthService.Errors;

public static class AuthErrors {
	public static Error TokenExpired => new("Auth.TokenExpired", "Token was expired", ErrorType.BadRequest);
	public static Error InvalidToken => new("Auth.InvalidToken", "Token is not valid", ErrorType.BadRequest);

	public static Error UnhandledError(Exception exception) {
		return new("Auth.UnhandledError", $"An unhandled error occurred. {exception.Message}", ErrorType.BadRequest);
	}
}