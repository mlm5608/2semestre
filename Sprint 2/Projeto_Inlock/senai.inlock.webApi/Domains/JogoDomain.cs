using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class JogoDomain
    {
        public int IdJogo { get; set; }

        [Required(ErrorMessage = "É necessario o estudio que criou o jogo")]
        public string IdEstudio { get; set; }

        [Required(ErrorMessage = "É necessario o nome do jogo")]
        public string Nome { get; set; }
        public string descricao { get; set; }

        [Required(ErrorMessage = "É necessaria a data do lançamento")]
        public DateTime? DataDeLançamento { get; set; }

        [Required(ErrorMessage = "O jogo precisa de um preço")]
        public decimal Preco { get; set; } 

        //Instancia do Estudio
        public EstudioDomain? Estudio { get; set; }
    }
}
