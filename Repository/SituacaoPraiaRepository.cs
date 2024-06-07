using gs_bluehorizon_dotnet.Data;
using gs_bluehorizon_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace gs_bluehorizon_dotnet.Repository;

public class SituacaoPraiaRepository
{
    private readonly BlueHorizonDbContext _context;

    public SituacaoPraiaRepository(BlueHorizonDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<SituacaoPraia>> FindAll()
    {
        return await _context.SituacaoPraias.ToListAsync();
    }

    public async Task<SituacaoPraia> FindById(long id)
    {
        return await _context.SituacaoPraias.FirstOrDefaultAsync(i => i.Id == id);
    }

    public bool Add(SituacaoPraia situacaoPraia)
    {
        _context.Add(situacaoPraia);
        return Save();
    }

    public bool Update(SituacaoPraia situacaoPraia)
    {
        _context.Update(situacaoPraia);
        return Save();
    }

    public bool Delete(SituacaoPraia situacaoPraia)
    {
        _context.Remove(situacaoPraia);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}