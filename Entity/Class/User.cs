
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    [Key]
    [Required]
    public Guid Id { get; set; }
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "The 'Email' field is required.")]
    public string Email { get; set; }
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "The 'Password' field is required.")]
    public string Password { get; set; }
    public int ProfileId { get => _profile.Id; set => _profile.Id = value; }
    [NotMapped, ForeignKey(nameof(ProfileId))]
    public IProfile Profile { get => _profile; set => _profile = value; }
    #endregion
}
