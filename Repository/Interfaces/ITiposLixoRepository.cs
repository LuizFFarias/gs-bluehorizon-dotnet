using gs_bluehorizon_dotnet.Models;

namespace gs_bluehorizon_dotnet.Repository.Interfaces;

public interface ITiposLixoRepository
{
    Task<IEnumerable<TiposLixo>> FindAll();

    Task<TiposLixo> FindById(long id);

    Task<TiposLixo> FindByName(string nome);

    bool Add(TiposLixo tiposLixo);
    
    bool Update(TiposLixo tiposLixo);

    bool Delete(TiposLixo tiposLixo);

    bool Save();
}