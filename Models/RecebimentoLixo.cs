using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gs_bluehorizon_dotnet.Models;

[Table("recebimento_lixo")]
public class RecebimentoLixo
{
    [Key]
    [Column("id_recebimento")]
    public long Id { get; set; }
        
    [Required(ErrorMessage = "A data de recebimento do lixo é obrigatório.")]
    [Column("dt_recebimento")]
    public DateTime DtRecebimento { get; set; }

    public ICollection<VoluntarioPerfil> Perfils { get; } = new List<VoluntarioPerfil>();

    public ICollection<PontosColeta> PontosColetas { get; } = new List<PontosColeta>();

    public ICollection<TiposLixo> TiposLixos { get; } = new List<TiposLixo>();

    public ICollection<VoluntarioPessoa> VoluntarioPessoas { get; } = new List<VoluntarioPessoa>();
}