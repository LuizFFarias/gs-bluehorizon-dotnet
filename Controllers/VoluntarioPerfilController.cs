using gs_bluehorizon_dotnet.Models;
using gs_bluehorizon_dotnet.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gs_bluehorizon_dotnet.Controllers;

public class VoluntarioPerfilController : Controller
{
    private readonly IVoluntarioPerfilRepository _repository;
    private readonly IVoluntarioPessoaRepository _pessoaRepository;

    public VoluntarioPerfilController(IVoluntarioPerfilRepository repository, IVoluntarioPessoaRepository pessoaRepository)
    {
        _repository = repository;
        _pessoaRepository = pessoaRepository;

    }

    public async Task<IActionResult> Index(long id)
    {
        var perfil = await _repository.FindById(id);
        if (perfil == null)
        {
            return NotFound();
        }
        return View(perfil);
    }

    public IActionResult Cadastrar(long id)
    {
        var perfil = new VoluntarioPerfil()
        {
            PessoaId = id
        };
        return View(perfil);
    }
    
    [HttpPost]
    public async Task<IActionResult> Cadastrar(VoluntarioPerfil perfil)
    {
       var  pessoa = await  _pessoaRepository.FindById(perfil.PessoaId);
       
        if ( pessoa != null)
        {
            perfil.VoluntarioPessoa = pessoa;
            
            _repository.Add(perfil);
            return RedirectToAction("Index", "VoluntarioPerfil", new {id = perfil.Id});
        }

        return View(perfil);
    }
    
    public async Task<IActionResult> Editar(long id)
    {
        var perfil = await _repository.FindById(id);
        if (perfil == null)
        {
            return NotFound();
        }
        return View(perfil);
    }
    
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(VoluntarioPerfil perfil)
    {
        if (perfil != null)
        {
            try
            {
                _repository.Update(perfil);
                return RedirectToAction("Index", "Home");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoluntarioPerfilExists(perfil.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        return View(perfil);
    }

    private bool VoluntarioPerfilExists(long id)
    {
        return _repository.FindById(id) != null;
    }

    public async Task<IActionResult> PerfilLogado(long id)
    {
        var perfil = _repository.FindByPessoaId(id);
        return RedirectToAction("Index", "VoluntarioPerfil", new {id = perfil.Id });
    } 
}