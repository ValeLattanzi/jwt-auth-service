using JWTAuthService.Domain.Contract;
using JWTAuthService.Entity.Class;
using JWTAuthService.Infrastructure.Data;
using JWTAuthService.Infrastructure.Repository;
using result_pattern;

namespace JWTAuthService.Domain.UseCase;

public class SendVerificationEmail : ISendVerificationEmail {
	private readonly IGenerateToken _generateToken;
	private readonly ISendEmail _sendEmail;

	public SendVerificationEmail(IGenerateToken generateToken, ISendEmail sendEmail) {
		_generateToken = generateToken;
		_sendEmail = sendEmail;
	}

	public async Task<Result> SendEmail(User user, SmptConfiguration smptConfiguration, string appName, Uri frontEndUrl,
		Uri appLogoUrl) {
		// 1. Create token
		var token = _generateToken.GenerateVerificationToken(user.Id, user.Email);

		// 2. Send email
		var emailBody = $@"
      <div
  style=""
    display: flex;
    flex-direction: column;
    align-items: center;
    padding: 1rem;
    border: 1px solid #ccc;
    border-radius: 5px;
    box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
    font-family: Arial, sans-serif;
    background-color: black;
    color: white;
  ""
>
  <img
    src={appLogoUrl}
    alt=""appLogo""
    style=""width: 100px; height: 100px; border-radius: 50%; margin: 1rem 0""
  />
  <h1 style=""font-size: 1.5rem; text-transform: uppercase"">
    Verify your email
  </h1>
  <div style=""font-size: 1.1rem; margin: 1rem 0; text-align: center"">
    <p>Click the link below to verify your email</p>
    <a
      href=""{frontEndUrl}/auth/verify-email?token={token}""
      type=""button""
      style=""
        padding: 0.5rem 1rem;
        background-color: #d30000;
        color: white;
        text-decoration: none;
        border: none;
        border-radius: 5px;
        cursor: pointer;
      ""
      >Verify email</a
    >
    <p>If you didn't request this email, you can ignore it</p>
  </div>
</div>
    ";
		var sendEmailRequest = new SendEmailRequest(user.Email, $"{appName} - Email Verification", emailBody);
		await _sendEmail.Notificate(smptConfiguration, sendEmailRequest, appName);
		return Result.success(true);
	}
}