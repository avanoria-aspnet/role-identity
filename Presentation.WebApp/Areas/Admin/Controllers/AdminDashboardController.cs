using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin")]
//[Authorize(Roles = "Admin, Employee")]
public class AdminDashboardController : Controller
{

    [HttpGet("")]
    public IActionResult Index()
    {
        ViewData["Title"] = "Dashboard";
        return View();
    }
}
