using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/memberships")]
[Authorize(Roles = "Admin, Employee")]
public class AdminMembershipsController : Controller
{

    [HttpGet("")]
    public IActionResult Index()
    {
        ViewData["Title"] = "Memberships";
        return View();
    }
}
