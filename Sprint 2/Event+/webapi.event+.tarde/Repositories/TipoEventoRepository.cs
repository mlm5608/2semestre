using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private readonly EventContext _eventContext;

        public TipoEventoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, TipoEvento tipoEvento)
        {
            try
            {
                TipoEvento tipo = _eventContext.TipoEvento.Find(id)!;

                if (tipo != null)
                {
                    tipo.Titulo = tipoEvento.Titulo;
                }
                _eventContext.TipoEvento.Update(tipo!);
                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public TipoEvento BuscarPorId(Guid id)
        {
            try
            {
                return _eventContext.TipoEvento.FirstOrDefault(e => e.IdTipoEvento == id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(TipoEvento novoTipo)
        {
            try
            {
                _eventContext.TipoEvento.Add(novoTipo);

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
                TipoEvento tipo = _eventContext.TipoEvento.Find(id)!;

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

        public List<TipoEvento> Listar()
        {
            try
            {
                return _eventContext.TipoEvento.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
