using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Areas.Me.Controllers;

[Area("Me")]
[Route("me/bookings")]
[Authorize(Roles = "Member")]
public class MeBookingsController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        ViewData["Title"] = "My Bookings";
        return View();
    }
}
