using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Areas.Authentication.Controllers;

[Area("Authentication")]
public class AuthenticationController : Controller
{
    [HttpGet("registration/sign-up")]
    [AllowAnonymous]
    public IActionResult SignUp()
    {
        if (User.Identity?.IsAuthenticated == true)
            return RedirectToAction("Index", "My");

        ViewData["Title"] = "Become a Member";

        return View();
    }


    [HttpGet("registration/set-password")]
    [AllowAnonymous]
    public IActionResult SetPassword()
    {
        if (User.Identity?.IsAuthenticated == true)
            return RedirectToAction("Index", "My");

        ViewData["Title"] = "Set Password";

        return View();
    }

    [HttpGet("sign-in")]
    [AllowAnonymous]
    public IActionResult SignIn()
    {
        if (User.Identity?.IsAuthenticated == true)
            return RedirectToAction("Index", "My");

        ViewData["Title"] = "Sign In";

        return View();
    }

    [HttpPost("sign-out")]
    [Authorize]
    public new IActionResult SignOut()
    {
        return RedirectToAction(nameof(SignIn));
    }
}
