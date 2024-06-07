using gs_bluehorizon_dotnet.Models;
using gs_bluehorizon_dotnet.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace gs_bluehorizon_dotnet.Controllers;

public class TiposLixoController : Controller
{
    private readonly ITiposLixoRepository _repository;

    public TiposLixoController(ITiposLixoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var tipos = await _repository.FindAll();
        return View(tipos);
    }

    public IActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar(TiposLixo tiposLixo)
    {
        if (ModelState.IsValid)
        {
            _repository.Add(tiposLixo);
            return RedirectToAction("Index",  "TiposLixo");
        }

        return View(tiposLixo);
    }
}