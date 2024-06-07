using gs_bluehorizon_dotnet.Data;
using gs_bluehorizon_dotnet.Models;
using gs_bluehorizon_dotnet.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace gs_bluehorizon_dotnet.Repository;

public class PontosColetaRepository : IPontosColetaRepository
{
    private readonly BlueHorizonDbContext _context;

    public PontosColetaRepository(BlueHorizonDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<PontosColeta>> FindAll()
    {
        return await _context.PontosColetas.ToListAsync();
    }

    public async Task<PontosColeta> FindById(long id)
    {
        return await _context.PontosColetas.FirstOrDefaultAsync(i => i.Id == id);
    }

    public bool Add(PontosColeta pontosColeta)
    {
        _context.Add(pontosColeta);
        return Save();
    }

    public bool Update(PontosColeta pontosColeta)
    {
        _context.Update(pontosColeta);
        return Save();
    }

    public bool Delete(PontosColeta pontosColeta)
    {
        _context.Remove(pontosColeta);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}