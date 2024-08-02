using JWTAuthService.Entity.Interface;

namespace JWTAuthService.Entity.Class;

public class Profile : IProfile
{
    private enum Profiles
    {
        NONE = 0,
        ADMIN,
        BASIC
    }
    private Profile(Profiles profile)
    {
        ID = (int)profile;
        Name = profile.ToString();
    }

    #region Attributes
    public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    #endregion

    #region Responsibilities
    public static Profile CreateAdmin()
    {
        return new Profile(Profiles.ADMIN);
    }

    public static Profile CreateBasic()
    {
        return new Profile(Profiles.BASIC);
    }

    public static Profile CreateNONE()
    {
        return new Profile(Profiles.NONE);
    }
    #endregion
}
