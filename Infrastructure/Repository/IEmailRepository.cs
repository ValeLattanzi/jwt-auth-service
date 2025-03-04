using JWTAuthService.Infrastructure.Data;
using result_pattern;

namespace JWTAuthService.Infrastructure.Repository;

public interface IEmailRepository
{
	Result<bool> SendEmail(SendEmailRequest request, bool isHtml = true);
}