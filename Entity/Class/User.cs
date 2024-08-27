
using JWTAuthService.Entity.Interface;

namespace JWTAuthService.Entity.Class;

public class User : IUser
{
    private IProfile _profile;
    public User()
    {
        Email ??= "";
        Password ??= "";
        _profile = new Profile();
    }

    public User(string email, string password, IProfile profile) : this()
    {
        Email = email;
        Password = password;
        _profile = profile;
    }

    #region Attributes
    public Guid ID { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int IDProfile { get => _profile.ID; set => _profile.ID = value; }
    public IProfile Profile { get => _profile; set => _profile = value; }
    #endregion
}
