namespace JWTAuthService.Domain.UseCase;

using JWTAuthService.Infrastructure.Data;

public interface ISendEmail
{
  Task<bool> Notificate(SmptConfiguration smptConfiguration, SendEmailRequest request, string appName, bool isHtml = true);
}
