using webapi.inlock.tarde.CodeFirst.sln.Domains;

namespace webapi.inlock.tarde.CodeFirst.sln.Interfaces
{
    public interface IUsuarioRepository
    {
        UsuarioDomain Login(string email, string senha);

        void Cadastrar(UsuarioDomain user);
    }
}
