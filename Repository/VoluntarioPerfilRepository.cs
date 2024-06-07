using gs_bluehorizon_dotnet.Data;
using gs_bluehorizon_dotnet.Models;
using gs_bluehorizon_dotnet.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace gs_bluehorizon_dotnet.Repository;

public class VoluntarioPerfilRepository : IVoluntarioPerfilRepository
{
    private readonly BlueHorizonDbContext _context;
    
    public VoluntarioPerfilRepository(BlueHorizonDbContext context)
    {
        _context = context;
    }
    
    
    public async Task<IEnumerable<VoluntarioPerfil>> FindAll()
    {
        return await _context.VoluntarioPerfils.ToListAsync();
    }

    public async Task<VoluntarioPerfil> FindByPessoaId(long id)
    {
        return await _context.VoluntarioPerfils.FirstOrDefaultAsync(p => p.PessoaId == id);
    }

    public async Task<VoluntarioPerfil> FindById(long id)
    {
        return await _context.VoluntarioPerfils.FirstOrDefaultAsync(i => i.Id == id);
    }

    public bool Add(VoluntarioPerfil voluntarioPerfil)
    {
        _context.Add(voluntarioPerfil);
        return Save();
    }

    public bool Update(VoluntarioPerfil voluntarioPerfil)
    {
        _context.Update(voluntarioPerfil);
        return Save();
    }

    public bool Delete(VoluntarioPerfil voluntarioPerfil)
    {
        _context.Remove(voluntarioPerfil);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}