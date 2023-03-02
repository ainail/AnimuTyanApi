using System.Security.Claims;
using DataAccess.Exceptions;
using Logic.Services.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AnimuTyanApi.Controllers.User;

[Authorize]
public class UserController : BaseController
{
    private readonly UserService _userService;
    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public Task Register([FromBody]UserRegisterRequest request)
    {
        return _userService.Insert(new UserEntity(null, request.Email, request.Username, request.Password));
    }

    [AllowAnonymous]
    [HttpPost("signin")]
    public async Task<IActionResult> SignIn([FromBody] UserSignInRequest request)
    {
        var user = await _userService
            .FindByNameAsync(request.Username, request.Password);

        if (user is null)
        {
            return BadRequest(new UserAuthResponse(false, "Invalid credentials"));
        }

        var claims = new List<Claim>
        {
            new Claim(type: ClaimTypes.Name, value: request.Username),
            new Claim(type: ClaimTypes.Name, value: user.Username)
        };
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(identity),
            new AuthenticationProperties
            {
                IsPersistent = true,
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
            });

        return Ok(new UserAuthResponse(true, "Signed in successfully"));
    }

    [Authorize]
    [HttpGet("user")]
    public IActionResult GetUser()
    {
        var userClaims = User.Claims
            .Select(x => new UserClaimResponse(x.Type, x.Value))
            .ToList();

        return Ok(userClaims);
    }

    [Authorize]
    [HttpGet("signout")]
    public async Task SignOutAsync()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }

    //[HttpGet("{username}")]
    //public async Task<UserInfoResponse> GetUser(string username)
    //{
    //    var user = await _userService.FindByNameAsync(username);

    //    if (user == null)
    //    {
    //        throw new NotFoundException();
    //    }

    //    return new UserInfoResponse()
    //    {
    //        Id = user.Id,
    //        Email = user.Email,
    //        Username = user.Email
    //    };
    //}
}