using JWTAuthService.Entity.Interface;

namespace JWTAuthService.Entity.Class;

public class Profile : IProfile
{
    public Profile()
    {
        Name ??= "";
    }

    public Profile(string name) : this()
    {
        Name = name;
    }

    #region Attributes
    public int ID { get; set; }
    public string Name { get; set; }
    #endregion
}
