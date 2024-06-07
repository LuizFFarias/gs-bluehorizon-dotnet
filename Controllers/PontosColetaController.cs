using gs_bluehorizon_dotnet.Models;
using gs_bluehorizon_dotnet.Repository;
using gs_bluehorizon_dotnet.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace gs_bluehorizon_dotnet.Controllers;

public class PontosColetaController : Controller
{
    private readonly IPontosColetaRepository _repository;

    public PontosColetaController(IPontosColetaRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IActionResult> Index()
    {
        var pontos = await _repository.FindAll();
        return View(pontos);
    }

    public IActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar(PontosColeta pontosColeta)
    {
        if (ModelState.IsValid)
        {
            _repository.Add(pontosColeta);
            return RedirectToAction("Index", "Home");
        }

        return View(pontosColeta);
    }
}