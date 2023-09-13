using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.tarde.CodeFirst.sln.Domains
{
    [Table("Estudio")]
    public class EstudioDomain
    {
        [Key]
        public Guid IdEstudio { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string? Nome { get; set; }

        //referencia aos jogos
        public List<JogoDomain>? Jogo { get; set; }
    }
}
