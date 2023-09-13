using Microsoft.EntityFrameworkCore;
using webapi.inlock.tarde.dbFirst.Contexts;
using webapi.inlock.tarde.dbFirst.Domains;
using webapi.inlock.tarde.dbFirst.Interfaces;

namespace webapi.inlock.tarde.dbFirst.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        InLockContext context = new InLockContext();

        public void Atualizar(Guid id, Estudio estudio)
        {
            Estudio estudioBuscado = context.Estudios.Find(id)!;

            if (estudioBuscado != null)
            {
                estudioBuscado.Nome = estudio.Nome;
            }
            context.Estudios.Update(estudioBuscado!);
            context.SaveChanges();
        }

        public Estudio BuscarPorId(Guid id)
        {
            return context.Estudios.FirstOrDefault(e => e.IdEstudio == id)!;
        }

        public void Cadastrar(Estudio estudio)
        {
            context.Estudios.Add(estudio);
            context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Estudio estudioBuscado = context.Estudios.Find(id)!;

            if (estudioBuscado != null)
            {
                context.Remove(estudioBuscado);
            }
            context.SaveChanges();
        }

        public List<Estudio> Listar()
        {
            return context.Estudios.ToList();
        }

        public List<Estudio> ListarComJogos()
        {
            return context.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}
