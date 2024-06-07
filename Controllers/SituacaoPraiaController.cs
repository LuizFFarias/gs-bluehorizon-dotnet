using gs_bluehorizon_dotnet.Models;
using gs_bluehorizon_dotnet.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace gs_bluehorizon_dotnet.Controllers;

public class SituacaoPraiaController : Controller
{
    private readonly ISituacaoPraiaRepository _repository;

    public SituacaoPraiaController(ISituacaoPraiaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var praias = await _repository.FindAll();
        return View(praias);
    }

    public IActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar(SituacaoPraia situacaoPraia)
    {
        if (ModelState.IsValid)
        {
            _repository.Add(situacaoPraia);
            return RedirectToAction("Index", "SituacaoPraia");
        }

        return View(situacaoPraia);
    }
}