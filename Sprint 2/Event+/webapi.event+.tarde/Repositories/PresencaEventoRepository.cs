using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class PresencaEventoRepository : IPresencaEventoRepository
    {
        private readonly EventContext _eventcontext;

        public PresencaEventoRepository()
        {
            _eventcontext= new EventContext();
        }

        public void Atualizar(Guid id, PresencaEvento presenca)
        {
            PresencaEvento novaPresenca = _eventcontext.PresencaEvento.Find(id);

            if (novaPresenca != null)
            {
                novaPresenca.IdEvento = presenca.IdEvento;
                novaPresenca.IdUsuario = presenca.IdUsuario;
                novaPresenca.Situação = presenca.Situação;
            }

            _eventcontext.PresencaEvento.Update(novaPresenca!);
            _eventcontext.SaveChanges();
        }

        public PresencaEvento BuscarPorId(Guid id)
        {
            return _eventcontext.PresencaEvento.FirstOrDefault(p => p.IdPresecaEvento == id)!;
        }

        public void Cadastrar(PresencaEvento novaPresenca)
        {
            _eventcontext.PresencaEvento.Add(novaPresenca);
            _eventcontext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            PresencaEvento pres = _eventcontext.PresencaEvento.Find(id);
            if (pres != null) 
            {
                _eventcontext.Remove(pres);
            }
            _eventcontext.SaveChanges();
        }

        public List<PresencaEvento> Listar()
        {
            return _eventcontext.PresencaEvento.ToList();
        }

        public List<PresencaEvento> ListarMinhas(Guid id)
        {
            return _eventcontext.PresencaEvento.Where(e => e.IdUsuario == id).ToList();
        }
    }
}
