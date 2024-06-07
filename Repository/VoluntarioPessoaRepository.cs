using gs_bluehorizon_dotnet.Data;
using gs_bluehorizon_dotnet.Models;
using gs_bluehorizon_dotnet.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace gs_bluehorizon_dotnet.Repository;

public class VoluntarioPessoaRepository : IVoluntarioPessoaRepository
{
    private readonly BlueHorizonDbContext _context;
    
    public VoluntarioPessoaRepository(BlueHorizonDbContext context)
    {
        _context = context;
    }
    
    
    public async Task<IEnumerable<VoluntarioPessoa>> FindAll()
    {
        return await _context.VoluntarioPessoas.ToListAsync();
    }

    public async Task<VoluntarioPessoa> FindById(long id)
    {
        return await _context.VoluntarioPessoas.FirstOrDefaultAsync(i => i.Id == id);
    }

    public bool Add(VoluntarioPessoa voluntarioPessoa)
    {
        _context.Add(voluntarioPessoa);
        return Save();
    }

    public bool Update(VoluntarioPessoa voluntarioPessoa)
    {
        _context.Update(voluntarioPessoa);
        return Save();
    }

    public bool Delete(VoluntarioPessoa voluntarioPessoa)
    {
        _context.Remove(voluntarioPessoa);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}