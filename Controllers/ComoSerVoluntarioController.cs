using Microsoft.AspNetCore.Mvc;

namespace gs_bluehorizon_dotnet.Controllers;

public class ComoSerVoluntarioController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}