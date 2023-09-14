using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.tarde.CodeFirst.sln.Domains
{
    [Table("Usuarios")]
    [Index(nameof(Email), IsUnique = true)]
    public class UsuarioDomain
    {
        [Key]
        public Guid IdUsuario { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O email é obrigatório !")]
        
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "A senha é obrigatório !")]
        [StringLength(60, MinimumLength = 6, ErrorMessage ="A senha deve conter de 6 a 20 caracteres!")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O usuario dave ter um tipo !")]
        public Guid IdTipoDeUsuario { get; set; }

        [ForeignKey("IdTipoDeUsuario")]
        public TipoDeUsuarioDomain? TipoDeUsuario { get; set; }
    }
}
