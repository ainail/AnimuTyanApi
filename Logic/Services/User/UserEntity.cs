using Logic.Services.BaseService;

namespace Logic.Services.User;

public class UserEntity : BaseIdentityEntity
{
    public string Email { get; }
    public string Username { get; }
    public string Password { get; }

    public UserEntity(Guid? id, string email, string username, string password) : base(id)
    {
        Email = email;
        Username = username;
        Password = password;
    }
}