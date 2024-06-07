using gs_bluehorizon_dotnet.Models;

namespace gs_bluehorizon_dotnet.Repository.Interfaces;

public interface IVoluntarioPessoaRepository
{
    Task<IEnumerable<VoluntarioPessoa>> FindAll();

    Task<VoluntarioPessoa> FindById(long id);

    bool Add(VoluntarioPessoa voluntarioPessoa);
    
    bool Update(VoluntarioPessoa voluntarioPessoa);

    bool Delete(VoluntarioPessoa voluntarioPessoa);

    bool Save();
}