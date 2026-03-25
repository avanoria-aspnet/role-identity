using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers.Me;

[Route("me/bookings")]
[Authorize(Roles = "Member")]
public class MeBookingsController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }
}
