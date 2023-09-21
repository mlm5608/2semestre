using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.tarde.Domains
{
    [Table(nameof(PresencaEvento))]
    public class PresencaEvento
    {
        [Key]
        public Guid IdPresecaEvento { get; set; } = new Guid();

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "A situação do evento é necessária")]
        public bool Situação { get; set; }

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
