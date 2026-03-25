using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/activities")]
[Authorize(Roles = "Admin, Employee")]
public class AdminActivitiesController : Controller
{


    [HttpGet("")]
    public IActionResult Index()
    {
        ViewData["Title"] = "Activities";
        return View();
    }
}