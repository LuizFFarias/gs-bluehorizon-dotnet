using gs_bluehorizon_dotnet.Models;

namespace gs_bluehorizon_dotnet.Repository.Interfaces;

public interface IRecebimentoLixoRepository
{
    Task<IEnumerable<RecebimentoLixo>> FindAll();

    Task<RecebimentoLixo> FindById(long id);

    bool Add(RecebimentoLixo recebimentoLixo);
    
    bool Update(RecebimentoLixo recebimentoLixo);

    bool Delete(RecebimentoLixo recebimentoLixo);

    bool Save();
}