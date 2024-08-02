
using JWTAuthService.Entity.Interface;

namespace JWTAuthService.Entity.Class;

public class User : IUser
{
    private IProfile _profile;
    public User()
    {
        Email ??= "";
        Password ??= "";
        _profile = Class.Profile.CreateNONE();
    }

    public User(string email, string password, IProfile profile) : this()
    {
        Email = email;
        Password = password;
    }

    #region Attributes
    public string Email { get; set; }
    public string Password { get; set; }
    public IProfile Profile { get => _profile; set => _profile = value; }
    #endregion
}
