using gs_bluehorizon_dotnet.Models;
using gs_bluehorizon_dotnet.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace gs_bluehorizon_dotnet.Controllers;

public class VoluntarioPessoaController : Controller
{
    private readonly IVoluntarioPessoaRepository _repository;
   

    public VoluntarioPessoaController(IVoluntarioPessoaRepository repository)
    {
        _repository = repository;
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
    public async Task<IActionResult> Cadastrar(VoluntarioPessoa pessoa)
    {
        if (ModelState.IsValid)
        {
            _repository.Add(pessoa);
            
            var id = pessoa.Id;
            return RedirectToAction("Cadastrar", "VoluntarioPerfil", new { id = id });
        }
        return View(pessoa);
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(VoluntarioPessoa voluntarioPessoa)
    {
        var voluntario = await _repository.FindLogin(voluntarioPessoa.CpfPessoa, voluntarioPessoa.SenhaPessoa);

        if (voluntario != null)
        {
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ViewBag.ErrorMessage = "Credenciais inválidas. Por favor, tente novamente.";
            return View("Login");
        }
    }
}