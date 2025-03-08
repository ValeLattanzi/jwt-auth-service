namespace JWTAuthService.Domain.Contract;

public interface IValidateUserByEmail
{
  Task<bool> ValidateUserByEmail(string email, string token);
}
