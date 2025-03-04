namespace JWTAuthService.Entity.Interface;

public interface IUser
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public IProfile Profile { get; set; }
}
