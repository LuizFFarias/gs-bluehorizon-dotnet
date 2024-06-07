using gs_bluehorizon_dotnet.Models;

namespace gs_bluehorizon_dotnet.Repository.Interfaces;

public interface ISituacaoPraiaRepository
{
    Task<IEnumerable<SituacaoPraia>> FindAll();

    Task<SituacaoPraia> FindById(long id);

    bool Add(SituacaoPraia situacaoPraia);
    
    bool Update(SituacaoPraia situacaoPraia);

    bool Delete(SituacaoPraia situacaoPraia);

    bool Save();
}