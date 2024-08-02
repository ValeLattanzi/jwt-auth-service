using JWTAuthService.Domain.Contract;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace JWTAuthService.Domain.UseCase;

public class ValidateToken : IValidateToken
{
    private readonly IConfiguration _configuration;

    public ValidateToken(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public bool IsExpired(string token, string key)
    {
        try
        {
            var _key = _configuration[key] ?? throw new Exception("Invalid Key");
            var _encodedKey = Encoding.ASCII.GetBytes(_key);
            var _tokenHandler = new JwtSecurityTokenHandler();
            _tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(_encodedKey),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true
            }, out SecurityToken _validatedToken);

            return _validatedToken.ValidTo < DateTime.UtcNow;
        }
        catch (Exception)
        {
            return true;
        }
    }
}
