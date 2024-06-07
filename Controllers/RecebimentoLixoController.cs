using gs_bluehorizon_dotnet.Models;
using Microsoft.AspNetCore.Mvc;

namespace gs_bluehorizon_dotnet.Controllers;

public class RecebimentoLixoController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Cadastrar()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Cadastrar(RecebimentoLixo recebimentoLixo)
    {
        return View();
    }
}