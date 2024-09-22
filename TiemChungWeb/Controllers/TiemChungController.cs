using Microsoft.AspNetCore.Mvc;

namespace TiemChungWeb.Controllers;

public class TiemChungController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}