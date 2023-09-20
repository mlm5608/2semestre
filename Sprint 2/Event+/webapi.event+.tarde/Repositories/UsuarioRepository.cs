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

        public void Atualizar(Guid id, Usuario usuario)
        {
            try
            {
                Usuario u = _eventContext.Usuario.Find(id);
                if (u != null) 
                { 
                    u.Email = usuario.Email;
                    u.Senha = usuario.Senha;
                    u.IdTipoUsuario = usuario.IdTipoUsuario;
                }
                _eventContext.Usuario.Update(u);
                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
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

                    TipoUsuario = new TipoUsuario
                    {
                        IdTipoUsuario = u.IdTipoUsuario,
                        Titulo = u.TipoUsuario!.Titulo
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

        public void Deletar(Guid id)
        {
            try
            {
                Usuario u = _eventContext.Usuario.Find(id)!;
                if (u != null)
                {
                    _eventContext.Remove(u);
                }
                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Usuario> Listar()
        {
            try
            {
                return _eventContext.Usuario.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
