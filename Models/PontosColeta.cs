using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gs_bluehorizon_dotnet.Models;

[Table("pontos_coleta")]
public class PontosColeta
{
    [Key]
    [Column("id_ponto")]
    public long Id { get; set; }

    [Required(ErrorMessage = "O nome do ponto é obrigatório.")]
    [Column("nome_ponto")]
    public string NomePonto { get; set; } = null!;
        
    [Required(ErrorMessage = "A UF do ponto é obrigatório.")]
    [StringLength(2, MinimumLength = 2, ErrorMessage = "A UF deve ter exatamente 2 caracteres.")]
    [Column("estado_ponto")]
    public string EstadoPonto { get; set; } = null!;
        
    [Required(ErrorMessage = "O nome do gerente do ponto é obrigatório.")]
    [Column("gerente_ponto")]
    public string GerentePonto { get; set; } = null!;

    public ICollection<RecebimentoLixo> RecebimentoLixos { get; } = new List<RecebimentoLixo>();
    
    
    
    
    
}