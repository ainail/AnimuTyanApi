using Logic.Services.User;

namespace Logic.Authentication;

public class BasicAuthenticationHandler 
{
    private readonly UserService _userService;
    public BasicAuthenticationHandler(UserService userService)
    {
        _userService = userService;
    }

    //protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    //{
    //    throw new NotImplementedException();
    //}
}