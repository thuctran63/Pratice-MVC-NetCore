using Microsoft.AspNetCore.Mvc;

namespace TiemChungWeb.Controllers;

public class CDController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}