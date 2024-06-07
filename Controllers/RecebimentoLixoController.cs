using gs_bluehorizon_dotnet.Models;
using gs_bluehorizon_dotnet.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    
    public IActionResult Index()
    {
        return View();
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
            return RedirectToAction("Index", "RecebimentoLixo");

        }
        return View(recebimentoLixo);
    }
}