using gs_bluehorizon_dotnet.Models;
using gs_bluehorizon_dotnet.Repository;
using gs_bluehorizon_dotnet.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return RedirectToAction("Index", "PontosColeta");
        }

        return View(pontosColeta);
    }
    
    public async Task<IActionResult> Editar(long id)
    {
        var pontosColeta = await _repository.FindById(id);
        if (pontosColeta == null)
        {
            return NotFound();
        }
        return View(pontosColeta);
    }
    
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(PontosColeta pontosColeta)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _repository.Update(pontosColeta);
                return RedirectToAction("Index", "PontosColeta");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PontosColetaExists(pontosColeta.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        return View(pontosColeta);
    }

    private bool PontosColetaExists(long id)
    {
        return _repository.FindById(id) != null;
    }
}