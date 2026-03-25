using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/members")]
[Authorize(Roles = "Admin, Employee")]
public class AdminMembersController : Controller
{

    [HttpGet("")]
    public IActionResult Index()
    {
        ViewData["Title"] = "Our Members";
        return View();
    }
}
