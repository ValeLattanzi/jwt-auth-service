using result_pattern;

namespace JWTAuthService.Errors;

public static class EmailErrors
{
	public static Error FailOnSend(string message)
	{
		return new Error("Email.FailOnSend", "An error occurred while sending email", ErrorType.BadRequest);
	}

	public static Error SmptConfigurationNotProvided => new("Email.SmptConfigurationNotProvided", "SmptConfiguration is not provided", ErrorType.BadRequest);

	public static Error SendEmailRequestNotProvided => new("Email.SendEmailRequestNotProvided", "SendEmailRequest is not provided", ErrorType.BadRequest);
}