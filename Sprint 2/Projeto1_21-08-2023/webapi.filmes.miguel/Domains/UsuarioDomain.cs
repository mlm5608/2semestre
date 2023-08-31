namespace webapi.filmes.miguel.Domains
{
    /// <summary>
    /// Classe que Representa a entidade Usuario
    /// </summary>
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        public string? Nome { get; set; }

        public string? Email { get; set; }

        public string? Senha { get; set; }

        public bool Permissao { get; set; }
    }
}
