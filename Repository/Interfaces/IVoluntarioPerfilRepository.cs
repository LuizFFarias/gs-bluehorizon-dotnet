using gs_bluehorizon_dotnet.Models;

namespace gs_bluehorizon_dotnet.Repository.Interfaces;

public interface IVoluntarioPerfilRepository
{
    Task<IEnumerable<VoluntarioPerfil>> FindAll();

    Task<VoluntarioPerfil> FindByPessoaId(long id);
    
    Task<VoluntarioPerfil> FindById(long id);

    bool Add(VoluntarioPerfil voluntarioPerfil);
    
    bool Update(VoluntarioPerfil voluntarioPerfil);

    bool Delete(VoluntarioPerfil voluntarioPerfil);

    bool Save();
}