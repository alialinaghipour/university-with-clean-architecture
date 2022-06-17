using System.Security.Claims;
using Application.Contracts.Services;
using Application.Security;
using Application.ViewModels.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace WebMvc.Controllers;

public class AccountController : Controller
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    [Route("Register")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register(RegisterUserViewModel register)
    {
        if (!ModelState.IsValid)
            return View(register);

        var checkUser =
            await _userService.Check(register.UserName, register.Email);
        if (checkUser != CheckUserViewModel.Ok)
        {
            ViewBag.Check = checkUser;
            return View(register);
        }

        var user = new RegisterUserViewModel
        {
            Email = register.Email.Trim().ToLower(),
            Password = register.Password.Hash(),
            UserName = register.UserName
        };

        await _userService.Register(user);

        return View("SuccessRegister", register);
    }

    [Route("Login")]
    public IActionResult Login(string returnUrl = "/")
    {
        ViewBag.Return = returnUrl;
        return View();
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login(LoginUserViewModel login,
        string returnUrl)
    {
        if (!ModelState.IsValid)
            return View(login);

        if (!await _userService.IsExist(login.Email, login.Password))
        {
            ModelState.AddModelError("Email", "User Not Found ...");
            return View(login);
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, login.Email),
            new(ClaimTypes.NameIdentifier, login.Email)
        };
        var identity = new ClaimsIdentity(claims,
            CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);
        var properties = new AuthenticationProperties
        {
            IsPersistent = login.RememberMe
        };

        await HttpContext.SignInAsync(principal, properties);

        return Redirect(returnUrl);
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults
            .AuthenticationScheme);
        return Redirect("/");
    }
}