using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.miguel.Domains
{
    /// <summary>
    /// Classe que representa entidade/tabela Filme
    /// </summary>
    public class FilmeDomain
    {
        public int IdFilme { get; set; }
        [Required(ErrorMessage = "O titulo do filme é obrigatório!")]
        public string? Titulo { get; set; }

        public int IdGenero { get; set; }

        //Referencia para a classe Genero (Foreign Key)
        public GeneroDomain? Genero { get; set; }
    }
}
