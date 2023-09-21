using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public TipoUsuarioRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            try
            {
                TipoUsuario tipo = _eventContext.TipoUsuario.Find(id)!;

                if (tipo != null)
                {
                    tipo.Titulo = tipoUsuario.Titulo;
                }
                _eventContext.TipoUsuario.Update(tipo!);
                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            try
            {
                return _eventContext.TipoUsuario.Find(id)!;
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public void Cadastrar(TipoUsuario novoTipo)
        {
            try
            {
                _eventContext.TipoUsuario.Add(novoTipo);

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
                TipoUsuario tipo = _eventContext.TipoUsuario.Find(id)!;

                if (tipo != null)
                {
                    _eventContext.Remove(tipo);
                }
                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TipoUsuario> Listar()
        {
            try
            {
                return _eventContext.TipoUsuario.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
