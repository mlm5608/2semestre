using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapi.event_.tarde.Domains
{
    [Table(nameof(ComentarioEvento))]
    public class ComentarioEvento
    {

        [Key]
        public Guid IdComentarioEvento { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descrição do comentario obrigatória!")]
        public string? Descricao { get; set; }

        [Column(TypeName = "BIT")]
        public bool Exibe { get; set; }

        //ref a tabela Usuario
        [Required(ErrorMessage = "O tipo do evento é obrigatório!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        //ref a tabela Evento
        [Required(ErrorMessage = "O tipo do evento é obrigatório!")]
        public Guid IdEvento { get; set; }

        [ForeignKey(nameof(IdEvento))]
        public Evento? Evento { get; set; }
    }
}
