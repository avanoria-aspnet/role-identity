using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Areas.Me.Controllers;

[Area("Me")]
[Route("me/membership")]
//[Authorize(Roles = "Member")]
public class MeMembershipController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        ViewData["Title"] = "My Membership";
        return View();
    }
}