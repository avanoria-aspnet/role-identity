using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers.Me;

[Route("me/membership")]
[Authorize(Roles = "Member")]
public class MeMembershipController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }
}