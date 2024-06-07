using gs_bluehorizon_dotnet.Models;
using gs_bluehorizon_dotnet.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

    public IActionResult Index()
    {
        return View();
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
            return RedirectToAction("Index", "Home");
        }

        return View(perfil);
    }
}