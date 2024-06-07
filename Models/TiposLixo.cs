using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gs_bluehorizon_dotnet.Models;

[Table("tipos_lixo")]
public class TiposLixo
{
    [Key]
    [Column("id_lixo")]
    public long Id { get; set; }
        
    [Required(ErrorMessage = "O nome do lixo é obrigatório")]
    [Column("nome_lixo")]
    public string NomeLixo { get; set; } = null!;
        
    [Required(ErrorMessage = "O valor do kg do lixo é obrigatório")]
    [Column("valor_lixo")]
    public decimal ValorKgLixo { get; set; }
    
    [Column("id_recebimento")]
    public long? RecebimentoLixoId { get; set; }
    
    public RecebimentoLixo? RecebimentoLixo { get; set; }
    
}