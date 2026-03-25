using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Areas.Me.Controllers;

[Area("Me")]
[Route("me")]
//[Authorize(Roles = "Member")]
public class MeController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        ViewData["Title"] = "My Account";
        return View();
    }
}
