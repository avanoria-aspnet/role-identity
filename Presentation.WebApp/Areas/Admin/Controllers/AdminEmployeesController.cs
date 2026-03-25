using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/employees")]
//[Authorize(Roles = "Admin")]
public class AdminEmployeesController : Controller
{

    [HttpGet("")]
    public IActionResult Index()
    {
        ViewData["Title"] = "Our Employees";
        return View();
    }
}
