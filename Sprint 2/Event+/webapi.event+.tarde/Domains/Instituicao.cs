using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.tarde.Domains
{
    [Table(nameof(Instituicao))]
    [Index(nameof(CNPJ))]
    [Index(nameof(Endereco))]
    public class Instituicao
    {
        [Key]
        public Guid IdIntituicao { get; set; } = new Guid();

        [Column(TypeName = "CHAR(14)")]
        [Required(ErrorMessage = "CNPJ obrigatório")]
        [StringLength(14)]
        public string? CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(500)")]
        [Required(ErrorMessage = "Endereço obrigatório")]
        public string? Endereco { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Endereço obrigatório")]
        public string? NomeFantasia { get; set; }
    }
}
