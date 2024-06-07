using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gs_bluehorizon_dotnet.Models;

[Table(("voluntario_pessoa"))]
public class VoluntarioPessoa
{
    [Key]
    [Column("id_pessoa")]
    public long Id { get; set; }
    
    [Required(ErrorMessage = "O CPF é obrigatório.")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter exatamente 11 caracteres.")]
    [Column("cpf_pessoa")]
    public string CpfPessoa { get; set; } = null!;
    
    [Column("nome_pessoa")]
    public string Nome { get; set; } = null!;
    
    [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
    [Column("dtnasc_pessoa")]
    public DateTime DtnascPessoa { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória.")]
    [Column("senha_pessoa")]
    public string SenhaPessoa { get; set; } = null!;

    [Required(ErrorMessage = "O CEP é obrigatório.")]
    [StringLength(8, MinimumLength = 8, ErrorMessage = "O CEP deve ter exatamente 8 números.")]
    [Column("cep_end")]
    public string CepEndereco { get; set; } = null!;

    [Required(ErrorMessage = "A rua é obrigatória.")]
    [Column("rua_end")]
    public string RuaEndereco { get; set; } = null!;

    [Required(ErrorMessage = "O número é obrigatório")]
    [Column("num_end")]
    public string NumEndereco { get; set; } = null!;
        
    [Required(ErrorMessage = "O bairro é obrigatório")]
    [Column("bairro_end")]
    public string BairroEndereco { get; set; } = null!;
        
    [Required(ErrorMessage = "A cidade é obrigatória")]
    [Column("cidade_end")]
    public string CidadeEndereco { get; set; } = null!;
        
    [Required(ErrorMessage = "O estado é obrigatório")]
    [Column("estado_end")]
    public string EstadoEndereco { get; set; } = null!;
        
    [Required(ErrorMessage = "O país é obrigatório")]
    [Column("pais_end")]
    public string PaisEndereco { get; set; } = null!;
    
    public VoluntarioPerfil? Perfil { get; set; }
    
    [Column("id_recebimento")]
    public long? RecebimentoLixoId { get; set; }
    
    public RecebimentoLixo? RecebimentoLixo { get; set; }
}