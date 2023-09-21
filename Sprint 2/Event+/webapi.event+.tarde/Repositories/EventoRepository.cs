using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext _eventContext;

        public EventoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, Evento evento)
        {
            Evento evnt = _eventContext.Evento.Find(id)!;

            if (evnt != null) 
            { 
                evnt.IdIntituicao = evento.IdIntituicao;
                evnt.Descricao = evento.Descricao;
                evnt.IdTipoEvento = evento.IdTipoEvento;
                evnt.NomeEvento = evento.NomeEvento;
                evnt.DataEvento = evento.DataEvento;
            }
            _eventContext.Evento.Update(evnt!);
            _eventContext.SaveChanges();
        }

        public Evento BuscarPorId(Guid id)
        {

            try
            {
                return _eventContext.Evento.FirstOrDefault(e => e.IdEvento == id)!;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void Cadastrar(Evento novoEvento)
        {
            try
            {
                _eventContext.Evento.Add(novoEvento);
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
                Evento evnt = _eventContext.Evento.Find(id)!;

                if (evnt != null) 
                { 
                    _eventContext.Evento.Remove(evnt);
                }

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Evento> Listar()
        {
            try
            {
                return _eventContext.Evento.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }    
}
