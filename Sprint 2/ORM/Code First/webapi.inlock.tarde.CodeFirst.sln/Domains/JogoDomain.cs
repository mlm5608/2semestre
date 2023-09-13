using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.tarde.CodeFirst.sln.Domains
{
    [Table("Jogos")]
    public class JogoDomain
    {
        [Key]
        public Guid IdJogo { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string? Nome { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descrição é necessária")]
        public string? Descricao { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data de lançamento é necessária")]
        public DateTime DataLancamento { get; set; }

        [Column(TypeName = "DECIMAL(4,2)")]
        [Required(ErrorMessage = "O é necessária")]
        public decimal Preco { get; set; }

        //ref tabela de estudio (Foreign key)
        public Guid IdEstudio { get; set; }

        [ForeignKey("IdEstudio")]
        public EstudioDomain? estudio { get; set; }
    }
}
