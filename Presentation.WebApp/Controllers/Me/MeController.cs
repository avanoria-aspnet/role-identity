using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers.Me;

[Route("me")]
[Authorize(Roles = "Member")]
public class MeController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }
}
