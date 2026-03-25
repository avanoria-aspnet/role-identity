using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/contact-requests")]
[Authorize(Roles = "Admin, Employee")]
public class AdminContactRequestsController : Controller
{

    [HttpGet("")]
    public IActionResult Index()
    {
        ViewData["Title"] = "Contact Requests";
        return View();
    }
}
