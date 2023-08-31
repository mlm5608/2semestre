using webapi.filmes.miguel.Domains;

namespace webapi.filmes.miguel.Interfaces
{
    public interface IUsuarioRepository
    {
        UsuarioDomain login(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
