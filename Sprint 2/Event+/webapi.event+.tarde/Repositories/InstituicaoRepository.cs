using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventContext _eventContext;

        public InstituicaoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, Instituicao instituicao)
        {
            try
            {
                Instituicao inst = _eventContext.Instituicao.Find(id)!;

                if (inst != null)
                {
                    inst.CNPJ = instituicao.CNPJ;
                    inst.Endereco = instituicao.Endereco;
                    inst.NomeFantasia = instituicao.NomeFantasia;
                }
                _eventContext.Instituicao.Update(inst!);
                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Instituicao BuscarPorId(Guid id)
        {
            try
            {
                return _eventContext.Instituicao.FirstOrDefault(e => e.IdIntituicao == id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Instituicao novaInstituicao)
        {
            try
            {
                _eventContext.Instituicao.Add(novaInstituicao);

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
                Instituicao inst = _eventContext.Instituicao.Find(id)!;

                if (inst != null)
                {
                    _eventContext.Remove(inst);
                }
                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Instituicao> Listar()
        {
            try
            {
                return _eventContext.Instituicao.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
