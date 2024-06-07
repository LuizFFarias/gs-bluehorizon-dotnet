using gs_bluehorizon_dotnet.Data;
using gs_bluehorizon_dotnet.Models;
using gs_bluehorizon_dotnet.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace gs_bluehorizon_dotnet.Repository;

public class TiposLixoRepository : ITiposLixoRepository
{
    private readonly BlueHorizonDbContext _context;

    public TiposLixoRepository(BlueHorizonDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<TiposLixo>> FindAll()
    {
        return await _context.TiposLixos.ToListAsync();
    }

    public async Task<TiposLixo> FindById(long id)
    {
        return await _context.TiposLixos.FirstOrDefaultAsync(i => i.Id == id);
    }

    public bool Add(TiposLixo tiposLixo)
    {
        _context.Add(tiposLixo);
        return Save();
    }

    public bool Update(TiposLixo tiposLixo)
    {
        _context.Update(tiposLixo);
        return Save();
    }

    public bool Delete(TiposLixo tiposLixo)
    {
        _context.Remove(tiposLixo);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}