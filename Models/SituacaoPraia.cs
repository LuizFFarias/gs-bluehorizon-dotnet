using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gs_bluehorizon_dotnet.Models;

[Table("Situacao_Praia")]
public class SituacaoPraia
{
        [Key]
        [Column("id_praia")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O nome da praia é obrigatório")]
        [Column("nome_praia")]
        public string NomePraia { get; set; } = null!;
        
        [Required(ErrorMessage = "O nível de sujeira da praia é obrigatório")]
        [Column("nivelsujeira_praia")]
        public int NivelSujeiraPraia { get; set; }

        [Required(ErrorMessage = "A cidade da praia é obrigatório")]
        [Column("cidade_praia")]
        public string CidadePraia { get; set; } = null!;
    
}