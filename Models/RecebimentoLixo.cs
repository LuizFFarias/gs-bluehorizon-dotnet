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
    public DateOnly DtRecebimento { get; set; }

    [Column("id_pontosColeta")]
    public long? PontosColetaId { get; set; }
    
    public PontosColeta? PontosColeta { get; set; }
    
    [Column("id_perfil")]
    public long? PerfilId { get; set; }
    
    public VoluntarioPerfil? VoluntarioPerfil { get; set; }
    
    [Column("id_pessoa")]
    public long? PessoaId { get; set; }
    
    public VoluntarioPessoa? VoluntarioPessoa { get; set; }

    public ICollection<TiposLixo> TiposLixos { get; } = new List<TiposLixo>();
    
    [NotMapped]
    public string PessoaCpf { get; set; }
    
    [NotMapped]
    public string NomePonto { get; set; }
    
    
    
}