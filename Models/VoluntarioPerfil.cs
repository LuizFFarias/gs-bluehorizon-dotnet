using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gs_bluehorizon_dotnet.Models;

[Table("voluntario_perfil")]
public class VoluntarioPerfil
{
    [Key]
    [Column("id_perfil")]
    public long Id { get; set; }
    
    [Required(ErrorMessage = "O valor do lixo retirado precisa ser, no mínimo, 0kg.")]
    [Column("qntdlixoretirado_perfil")]
    public int QntdLixo { get; set; }
    
    public long PessoaId { get; set; }
    
    public VoluntarioPessoa VoluntarioPessoa { get; set; } = null!;
}