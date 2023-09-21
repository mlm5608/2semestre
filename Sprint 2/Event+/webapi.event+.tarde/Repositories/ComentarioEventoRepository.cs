using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        private readonly EventContext _eventContext;

        public ComentarioEventoRepository()
        {
            _eventContext = new EventContext();
        }

        public ComentarioEvento BuscarPorId(Guid id)
        {
            try
            {
                return _eventContext.ComentarioEvento.FirstOrDefault(e => e.IdComentarioEvento == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(ComentarioEvento novoComentario)
        {
            try
            {
                _eventContext.ComentarioEvento.Add(novoComentario);
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
                ComentarioEvento coment = _eventContext.ComentarioEvento.Find(id)!;

                if (coment != null) 
                { 
                    _eventContext.ComentarioEvento.Remove(coment);
                }

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ComentarioEvento> Listar()
        {
            try
            {
                return _eventContext.ComentarioEvento.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
