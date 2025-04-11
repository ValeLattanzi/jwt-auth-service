namespace JWTAuthService.Domain.UseCase;

using JWTAuthService.Domain.Contract;
using JWTAuthService.Infrastructure.Data;
using JWTAuthService.Infrastructure.Service;

public class SendEmail : ISendEmail
{
  private readonly EmailService _emailService;

  public SendEmail(EmailService emailService)
  {
    _emailService = emailService;
  }

  public async Task<bool> Notificate(SmptConfiguration smptConfiguration, SendEmailRequest request, string appName, bool isHtml = true)
  {
    try
    {
      await _emailService.SendEmail(smptConfiguration, request, appName, isHtml);
      return true;
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
      return false;
    }
  }
}