using gs_bluehorizon_dotnet.Models;
using gs_bluehorizon_dotnet.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    
    public async Task<IActionResult> Editar(long id)
    {
        var tiposLixo = await _repository.FindById(id);
        if (tiposLixo == null)
        {
            return NotFound();
        }
        return View(tiposLixo);
    }
    
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(TiposLixo tiposLixo)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _repository.Update(tiposLixo);
                return RedirectToAction("Index", "Home");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoLixoExists(tiposLixo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        return View(tiposLixo);
    }

    private bool TipoLixoExists(long id)
    {
        return _repository.FindById(id) != null;
    }
}