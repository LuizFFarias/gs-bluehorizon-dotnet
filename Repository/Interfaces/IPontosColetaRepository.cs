using gs_bluehorizon_dotnet.Models;

namespace gs_bluehorizon_dotnet.Repository.Interfaces;

public interface IPontosColetaRepository
{
    Task<IEnumerable<PontosColeta>> FindAll();

    Task<PontosColeta> FindById(long id);

    bool Add(PontosColeta pontosColeta);
    
    bool Update(PontosColeta pontosColeta);

    bool Delete(PontosColeta pontosColeta);

    bool Save();
}