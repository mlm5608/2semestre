using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.tarde.CodeFirst.sln.Domains
{
    [Table("Usuarios")]
    public class UsuarioDomain
    {
        [Key]
        public Guid IdUsuario { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O email é obrigatório !")]
        [Index(IsUnique = true)]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "A senha é obrigatório !")]
        [StringLength(20, MinimumLength = 6, ErrorMessage ="A senha deve conter de 6 a 20 caracteres!")]
        public string Senha { get; set; }

        public Guid IdTipoDeUsuario { get; set; }

        [ForeignKey("IdTipoDeUsuario")]
        public TipoDeUsuarioDomain? TipoDeUsuario { get; set; }
    }
}
