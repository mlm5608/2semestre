using senai.inlock.webApi.Domains;
using System.Data;

namespace senai.inlock.webApi.Interfaces
{
    public interface IUsuarioRepository
    {
        UsuarioDomain Login(string email, string senha);
    }
}
