using gs_bluehorizon_dotnet.Data;
using gs_bluehorizon_dotnet.Models;
using gs_bluehorizon_dotnet.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace gs_bluehorizon_dotnet.Repository;

public class RecebimentoLixoRepository : IRecebimentoLixoRepository
{
    private readonly BlueHorizonDbContext _context;

    public RecebimentoLixoRepository(BlueHorizonDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<RecebimentoLixo>> FindAll()
    {
        return await _context.RecebimentoLixos.ToListAsync();
    }

    public async Task<RecebimentoLixo> FindById(long id)
    {
        return await _context.RecebimentoLixos.FirstOrDefaultAsync(i => i.Id == id);
    }

    public bool Add(RecebimentoLixo recebimentoLixo)
    {
        _context.Add(recebimentoLixo);
        return Save();
    }

    public bool Update(RecebimentoLixo recebimentoLixo)
    {
        _context.Update(recebimentoLixo);
        return Save();
    }

    public bool Delete(RecebimentoLixo recebimentoLixo)
    {
        _context.Remove(recebimentoLixo);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}