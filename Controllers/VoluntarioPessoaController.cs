using gs_bluehorizon_dotnet.Models;
using gs_bluehorizon_dotnet.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gs_bluehorizon_dotnet.Controllers;

public class VoluntarioPessoaController : Controller
{
    private readonly IVoluntarioPessoaRepository _repository;
   

    public VoluntarioPessoaController(IVoluntarioPessoaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> Index(long id)
    {
        var pessoa = await _repository.FindById(id);
        if (pessoa == null)
        {
            return NotFound();
        }
        return View(pessoa);
    }

    public IActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar(VoluntarioPessoa pessoa)
    {
        DateOnly dataAtual = DateOnly.FromDateTime(DateTime.Now); 
        int idade = dataAtual.Year - pessoa.DtnascPessoa.Year;

        if (idade < 18 || idade > 100)
        {
            ViewBag.ErrorMessage = "Data inválida. Por favor, tente novamente.";
            return View(pessoa);
        }
        
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
            return RedirectToAction("Index", "VoluntarioPessoa", new {id = voluntario.Id});
        }
        else
        {
            ViewBag.ErrorMessage = "Credenciais inválidas. Por favor, tente novamente.";
            return View("Login");
        }
    }
    
    public async Task<IActionResult> Editar(long id)
    {
        var pessoa = await _repository.FindById(id);
        if (pessoa == null)
        {
            return NotFound();
        }
        return View(pessoa);
    }
    
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(VoluntarioPessoa pessoa)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _repository.Update(pessoa);
                return RedirectToAction("Index", "VoluntarioPessoa");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoluntarioPessoaExists(pessoa.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        return View(pessoa);
    }

    private bool VoluntarioPessoaExists(long id)
    {
        return _repository.FindById(id) != null;
    }

}