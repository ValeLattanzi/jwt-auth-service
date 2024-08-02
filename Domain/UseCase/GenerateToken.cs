using JWTAuthService.Domain.Contract;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTAuthService.Domain.UseCase;

public class GenerateToken : IGenerateToken
{
    private readonly IConfiguration _configuration;

    public GenerateToken(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerarAccessToken(string email, string accessKey)
    {        // 1.- Generar el AccessToken
        var _tokenHandler = new JwtSecurityTokenHandler();
        // 2.- Obtiene la clave para cifrar el token
        var _key = Encoding.ASCII.GetBytes(_configuration[accessKey] ?? throw new Exception("Invalid Json Key"));
        // 3.- Define la configuracion
        var _tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.Email, email)
            ]),
            Expires = DateTime.UtcNow.AddMinutes(5),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256Signature)
        };

        var _accessToken = WriteToken(_tokenHandler, _tokenDescriptor);

        return _accessToken;
    }

    public string GenerarRefreshToken(string email, string refreshKey)
    {
        var _tokenHandler = new JwtSecurityTokenHandler();
        var _refreshKey = Encoding.ASCII.GetBytes(_configuration[refreshKey] ?? throw new Exception("Invalid Json Key"));
        var _tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.Email, email)
            ]),
            Expires = DateTime.UtcNow.AddMinutes(20),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_refreshKey), SecurityAlgorithms.HmacSha256Signature)
        };

        var _refreshToken = WriteToken(_tokenHandler, _tokenDescriptor);
        return _refreshToken;
    }

    private static string WriteToken(JwtSecurityTokenHandler tokenHandler, SecurityTokenDescriptor tokenDescriptor)
    {
        var _token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(_token);
    }
}