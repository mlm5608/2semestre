using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Utils;

namespace webapi.event_.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public UsuarioRepository()
        {
            _eventContext = new EventContext();
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            Usuario usuarioBuscado = _eventContext.Usuario.FirstOrDefault(u => u.Email == email)!;

            if (usuarioBuscado != null)
            {
                bool conference = Criptografia.compararHash(senha, usuarioBuscado.Senha!);
                if (conference) 
                { 
                    return usuarioBuscado;
                }
            }
            return null;
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _eventContext.Usuario
                .Select(u => new Usuario
                {
                    IdTipoUsuario = u.IdTipoUsuario,
                    Nome = u.Nome,
                    Email = u.Email,

                    TipoUSuario = new TipoUsuario
                    {
                        IdTipoUsuario = u.IdTipoUsuario,
                        Titulo = u.TipoUSuario!.Titulo
                    }
                }).FirstOrDefault(u => u.IdUsuario == id)!;

                return usuarioBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Usuario novoUsuario)
        {

            try
            {
                novoUsuario.Senha = Criptografia.GerarHash(novoUsuario.Senha!);
                _eventContext.Usuario.Add(novoUsuario);
                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
