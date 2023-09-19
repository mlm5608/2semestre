using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.tarde.Domains
{
    [Table(nameof(Evento))]
    public class Evento
    {
        [Key]
        public Guid IdEvento { get; set; } = new Guid();

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data do evento é obrigatória!")]
        public DateTime DataEvento { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome do evento é obrigatório!")]
        public string? NomeEvento { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descricao é obrigatória!")]
        public string? Descricao { get; set; }

        //ref a tabela tipo evento
        [Required(ErrorMessage ="O tipo do evento é obrigatório!")]
        public Guid IdTipoEvento { get; set; }

        [ForeignKey(nameof(IdTipoEvento))]
        public TipoEvento? TipoEvento { get; set; }

        //ref a tabela instituicao
        [Required(ErrorMessage = "A instituticao é obrigatória!")]
        public Guid IdIntituicao { get; set; }

        [ForeignKey(nameof(IdIntituicao))]
        public Instituicao? Instituicao { get; set; }
    }
}
