using Application.Abstractions.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApp.Areas.Authentication.Models;

namespace Presentation.WebApp.Areas.Authentication.Controllers;

[Area("Authentication")]
public class AuthenticationController(IAuthService authService) : Controller
{
    [HttpGet("registration/sign-up")]
    [AllowAnonymous]
    public IActionResult SignUp()
    {
        var redirect = RedirectWhenLoggedIn;
        if (redirect is not null)
            return redirect;

        ViewData["Title"] = "Become a Member";

        return View();
    }


    [HttpGet("registration/set-password")]
    [AllowAnonymous]
    public IActionResult SetPassword()
    {
        var redirect = RedirectWhenLoggedIn;
        if (redirect is not null)
            return redirect;

        ViewData["Title"] = "Set Password";

        return View();
    }

    [HttpGet("sign-in")]
    [AllowAnonymous]
    public IActionResult SignIn(string? returnUrl = null)
    {
        var redirect = RedirectWhenLoggedIn;
        if (redirect is not null)
            return redirect;

        ViewData["Title"] = "Sign In";
        ViewBag.ReturnUrl = returnUrl;

        return View();
    }

    [HttpPost("sign-in")]
    [AllowAnonymous]
    public async Task<IActionResult> SignIn(SignInForm form, string? returnUrl = null)
    {
        var redirect = RedirectWhenLoggedIn;
        if (redirect is not null)
            return redirect;

        ViewData["Title"] = "Sign In";
        ViewBag.ReturnUrl = returnUrl;

        if (!ModelState.IsValid)
        {
            ModelState.AddModelError(nameof(form.ErrorMessage), "Incorrect email address or password");
            return View(form);
        }

        var result = await authService.SignInUserAsync(form.Email, form.Password, form.RememberMe);
        if (!result.Succeeded)
        {
            ModelState.AddModelError(nameof(form.ErrorMessage), result?.ErrorMessage ?? "Incorrect email address or password");
            return View(form);
        }

        if (!string.IsNullOrWhiteSpace(returnUrl) || Url.IsLocalUrl(returnUrl))
            return Redirect(returnUrl);

        if (User.IsInRole("Admin"))
            return RedirectToAction("Index", "AdminDashboard", new { area = "Admin" });

        if (User.IsInRole("Member"))
            return RedirectToAction("Index", "Me", new { area = "Me" });

        return Redirect("/");
    }


    [HttpPost("sign-out")]
    [Authorize]
    public new IActionResult SignOut()
    {
        return RedirectToAction(nameof(SignIn));
    }


    private IActionResult? RedirectWhenLoggedIn
    {
        get
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                if (User.IsInRole("Admin"))
                    return RedirectToAction("Index", "AdminDashboard", new { area = "Admin" });

                if (User.IsInRole("Member"))
                    return RedirectToAction("Index", "Me", new { area = "Me" });
            }

            return null;
        }
    }
}

