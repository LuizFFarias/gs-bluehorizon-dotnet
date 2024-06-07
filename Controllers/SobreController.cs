using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace gs_bluehorizon_dotnet.Controllers;

public class SobreController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}