using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.tarde.CodeFirst.sln.Domains
{
    [Table("TiposDeUsuario")]
    public class TipoDeUsuarioDomain
    {
        [Key]
        public Guid IdTipoDeUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string? Titulo { get; set; }
    }
}
