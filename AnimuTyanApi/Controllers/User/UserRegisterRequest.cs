using System.ComponentModel.DataAnnotations;

namespace AnimuTyanApi.Controllers.User;

public class UserRegisterRequest
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Email { get; set; }
}