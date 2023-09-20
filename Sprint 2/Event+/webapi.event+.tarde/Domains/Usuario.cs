using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace webapi.event_.tarde.Domains
{
    [Table(nameof(Usuario))]
    [Index(nameof(Email))]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = new Guid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Email é obrigatório!")]
        public string? Email { get; set; }

        [Column(TypeName = "CHAR(60)")]
        [Required(ErrorMessage = "Senha é obrigatória!")]
        [StringLength(60, MinimumLength =6, ErrorMessage ="Senha deve conter de 6 à 60 caracteres")]
        public string? Senha { get; set; }

        //ref table tipousuario
        [Required(ErrorMessage = "O tipo do usuario é obrigatório")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey(nameof(IdTipoUsuario))]
        public TipoUsuario? TipoUsuario { get; set; }


    }
}
