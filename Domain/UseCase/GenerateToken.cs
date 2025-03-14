using JWTAuthService.Domain.Contract;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTAuthService.Domain.UseCase;

public class GenerateToken : IGenerateToken {
	public string generateAccessToken(List<Claim> claims, string accessKey) {
		// 1.- Generar el AccessToken
		var _tokenHandler = new JwtSecurityTokenHandler();
		// 2.- Obtiene la clave para cifrar el token
		var _key = Encoding.ASCII.GetBytes(accessKey);
		// 3.- Define la configuracion
		var _tokenDescriptor = new SecurityTokenDescriptor {
			Subject = new(claims),
			Expires = DateTime.UtcNow.AddMinutes(5),
			SigningCredentials = new(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256Signature)
		};

		var _accessToken = writeToken(_tokenHandler, _tokenDescriptor);

		return _accessToken;
	}

	public string generateRefreshToken(List<Claim> claims, string refreshKey) {
		var _tokenHandler = new JwtSecurityTokenHandler();
		var _refreshKey = Encoding.ASCII.GetBytes(refreshKey);
		var _tokenDescriptor = new SecurityTokenDescriptor {
			Subject = new(claims),
			Expires = DateTime.UtcNow.AddMinutes(20),
			SigningCredentials = new(new SymmetricSecurityKey(_refreshKey), SecurityAlgorithms.HmacSha256Signature)
		};

		var _refreshToken = writeToken(_tokenHandler, _tokenDescriptor);
		return _refreshToken;
	}

	private static string writeToken(JwtSecurityTokenHandler tokenHandler, SecurityTokenDescriptor tokenDescriptor) {
		var _token = tokenHandler.CreateToken(tokenDescriptor);
		return tokenHandler.WriteToken(_token);
	}

	public string generateVerificationToken(Guid userId, string email) {
		var verificationSecretKey = "";
		var tokenHandler = new JwtSecurityTokenHandler();
		var key = Encoding.ASCII.GetBytes(verificationSecretKey); // TODO : implement a secret key to encrypt the token
		var tokenDescriptor = new SecurityTokenDescriptor() {
			Subject = new(
			[
				new("userId", userId.ToString()),
				new("email", email)
			]),
			Expires = DateTime.UtcNow.AddMinutes(10),
			SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
		};

		var token = tokenHandler.CreateToken(tokenDescriptor);
		return tokenHandler.WriteToken(token);
	}
}