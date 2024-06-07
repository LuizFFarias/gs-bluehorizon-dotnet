using gs_bluehorizon_dotnet.Models;
using gs_bluehorizon_dotnet.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    
    public async Task<IActionResult> Editar(long id)
    {
        var situacaoPraia = await _repository.FindById(id);
        if (situacaoPraia == null)
        {
            return NotFound();
        }
        return View(situacaoPraia);
    }
    
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(SituacaoPraia situacaoPraia)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _repository.Update(situacaoPraia);
                return RedirectToAction("Index", "SituacaoPraia");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SituacaoPraiaExists(situacaoPraia.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        return View(situacaoPraia);
    }

    private bool SituacaoPraiaExists(long id)
    {
        return _repository.FindById(id) != null;
    }
}