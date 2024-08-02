# Dependencies 🔐
- `Microsoft.AspNetCore.Mvc.Core`
- `Microsoft.AspNetCore.Authentication`
- `System.IdentityModel.Tokens.Jwt`
- `Microsoft.Extensions.Configuration.Abstractions`

# Usage 💻

- Add the use cases to the services in the `Program.cs`
- Configure the `AccessKey` and `RefreshKey` in the `appsettings.json` at the label `Jwt`
- Implement login controller using the `access token` and `refresh token`
- Implement controller to refresh the `access token`.

## Example
### Controller
```

[ApiController, Route("auth/refresh-access-token"), Authorize]
public class RefreshAccessTokenController : ControllerBase
{
    private readonly IRefreshAccessToken _refreshAccessToken;
    private readonly IConfiguration _configuration;
    private readonly IReadUser _readUser;

    public RefreshAccessTokenController(IRefreshAccessToken refreshAccessToken, IReadUser readUser, IConfiguration configuration)
    {
        _refreshAccessToken = refreshAccessToken;
        _readUser = readUser;
        _configuration = configuration;
    }

    [HttpPost]
    public async Task<ActionResult<AuthDTO>> RefreshAccessToken([FromBody] AuthDTO auth)
    {
        try
        {
            // Validate email
            // Implement the use case to read in your dbcontext if the user exist
            if (!_readUser.UserAlreadyExist(auth.Email))
            {
                return BadRequest("The user not exists");
            }
            var _accessKey = _configuration["Jwt:AccessKey"];
            if (string.IsNullOrEmpty(_accessKey))
                return BadRequest("Invalid Key");

            string _newAccessToken = _refreshAccessToken.Refresh(auth.Email, _accessKey);
            // Update the access token
            auth.AccessToken = _newAccessToken;

            return Ok(auth);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}
```
