using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApp.Controllers.Public;


[Route("")]
public class HomeController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }
}
