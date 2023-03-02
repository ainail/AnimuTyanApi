using System.ComponentModel.DataAnnotations;

namespace AnimuTyanApi.Controllers.User;

public class UserSignInRequest
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}