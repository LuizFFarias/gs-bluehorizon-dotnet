using gs_bluehorizon_dotnet.Models;
using gs_bluehorizon_dotnet.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gs_bluehorizon_dotnet.Controllers;

public class RecebimentoLixoController : Controller
{
    private readonly IRecebimentoLixoRepository _repository;
    private readonly IPontosColetaRepository _coletaRepository;
    private readonly IVoluntarioPerfilRepository _perfilRepository;
    private readonly IVoluntarioPessoaRepository _pessoaRepository;

    public RecebimentoLixoController( IRecebimentoLixoRepository repository, 
        IPontosColetaRepository coletaRepository, 
        IVoluntarioPerfilRepository perfilRepository, 
        IVoluntarioPessoaRepository pessoaRepository )
    {
        _repository = repository;
        _coletaRepository = coletaRepository;
        _perfilRepository = perfilRepository;
        _pessoaRepository = pessoaRepository;
    }
    
    public async Task<IActionResult> Index()
    {
        var recebimentos = await _repository.FindAll();
        return View(recebimentos);
    }

    public IActionResult Cadastrar()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Cadastrar(RecebimentoLixo recebimentoLixo)
    {
        var pessoa = await _pessoaRepository.FindByCpf(recebimentoLixo.PessoaCpf);
        if (pessoa == null)
        {
            ModelState.AddModelError("", "Pessoa não encontrada.");
            return View(recebimentoLixo);
        }

        var perfil = await _perfilRepository.FindByPessoaId(pessoa.Id);
        if (perfil == null)
        {
            ModelState.AddModelError("", "Perfil não encontrado.");
            return View(recebimentoLixo);
        }

        var coleta = await _coletaRepository.FindByName(recebimentoLixo.NomePonto);
        if (coleta == null)
        {
            ModelState.AddModelError("", "Ponto de coleta não encontrado.");
            return View(recebimentoLixo);
        }

        recebimentoLixo.PessoaId = pessoa.Id;
        recebimentoLixo.PerfilId = perfil.Id;
        recebimentoLixo.PontosColetaId = coleta.Id;
        
        if (ModelState.IsValid)
        {
            _repository.Add(recebimentoLixo);
            return RedirectToAction("Index", "Home");

        }
        return View(recebimentoLixo);
    }
    
    public async Task<IActionResult> Editar(long id)
    {
        var recebimentoLixo = await _repository.FindById(id);
        if (recebimentoLixo == null)
        {
            return NotFound();
        }
        return View(recebimentoLixo);
    }
    
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(RecebimentoLixo recebimentoLixo)
    {
        var pessoa = await _pessoaRepository.FindByCpf(recebimentoLixo.PessoaCpf);
        if (pessoa == null)
        {
            ModelState.AddModelError("", "Pessoa não encontrada.");
            return View(recebimentoLixo);
        }

        var perfil = await _perfilRepository.FindByPessoaId(pessoa.Id);
        if (perfil == null)
        {
            ModelState.AddModelError("", "Perfil não encontrado.");
            return View(recebimentoLixo);
        }

        var coleta = await _coletaRepository.FindByName(recebimentoLixo.NomePonto);
        if (coleta == null)
        {
            ModelState.AddModelError("", "Ponto de coleta não encontrado.");
            return View(recebimentoLixo);
        }

        recebimentoLixo.PessoaId = pessoa.Id;
        recebimentoLixo.PerfilId = perfil.Id;
        recebimentoLixo.PontosColetaId = coleta.Id;
        
        if (ModelState.IsValid)
        {
            try
            {
                _repository.Update(recebimentoLixo);
                return RedirectToAction("Index", "Home");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecebimentoExists(recebimentoLixo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        return View(recebimentoLixo);
    }
    
    private bool RecebimentoExists(long id)
    {
        return _repository.FindById(id) != null;
    }
    
    public async Task<IActionResult> Deletar(long id)
    {
        var recebimentoLixo = await _repository.FindById(id);
        if (recebimentoLixo == null)
        {
            return NotFound();
        }
        return View(recebimentoLixo);
    }

    [HttpPost, ActionName("Deletar")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeletarConfirmed(long id)
    {
        var recebimentoLixo = await _repository.FindById(id);
        if (recebimentoLixo != null)
        {
            _repository.Delete(recebimentoLixo);
            return RedirectToAction("Index", "Home");
        }
        return NotFound();
    }
}