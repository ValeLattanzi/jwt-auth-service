using JWTAuthService.Errors;
using JWTAuthService.Infrastructure.Data;
using JWTAuthService.Infrastructure.Repository;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using result_pattern;

namespace JWTAuthService.Infrastructure.Service;

public sealed class EmailService(
	IConfiguration configuration
) : IEmailRepository {
	public Result<bool> SendEmail(SendEmailRequest request, bool isHtml = true) {
		try {
			var username = configuration["Smtp:User"];
			// * Create a new email message
			var message = new MimeMessage();
			// * Add the sender
			message.From.Add(new MailboxAddress("Z Pay", username));
			// * Add the recipient
			message.To.Add(new MailboxAddress(request.To, request.To));
			// * Add the subject
			message.Subject = request.Subject;
			// * Add the body
			message.Body = new TextPart(isHtml ? "html" : "plain") {
				Text = request.Body
			};

			// * Create a new SMTP client
			using var client = new MailKit.Net.Smtp.SmtpClient();
			// * Connect to the SMTP server
			var password = configuration["Smtp:Password"];
			var host = configuration["Smtp:Host"];
			var port = int.Parse(configuration["Smtp:Port"]!);

			client.Connect(host, port, SecureSocketOptions.StartTls);

			// * Authenticate with the SMTP server
			client.Authenticate(username, password);

			// * Send the email
			client.SendAsync(message);

			// * Disconnect from the SMTP server
			client.Disconnect(true);

			return Result.success(true);
		}
		catch (Exception ex) {
			return Result<bool>.failure(EmailErrors.FailOnSend(ex.Message));
		}
	}
}