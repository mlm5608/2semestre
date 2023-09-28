using webapi.healthClinic.miguel.Contexts;
using webapi.healthClinic.miguel.Domains;
using webapi.healthClinic.miguel.Interfaces;

namespace webapi.healthClinic.miguel.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private Context _context { get; set; }
        public ComentarioRepository()
        {
            _context= new Context();
        }
        public Comentario BuscarPorPaciente(string cpf)
        {
            return _context.Comentario.FirstOrDefault(c => c.Consulta!.Paciente!.CPF == cpf)!;
        }

        public void Cadastrar(Comentario c)
        {
            _context.Comentario.Add(c);
            _context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Comentario comnt = _context.Comentario.Find(id)!;
            if (comnt != null)
            {
                _context.Remove(comnt);
            }
            _context.SaveChanges();
        }

        public List<Comentario> ListarMeus(Guid id)
        {
            Paciente pac = _context.Paciente.Find(id)!;
            List<Comentario> list = new List<Comentario>();

            foreach (Comentario comnt in _context.Comentario)
            {
                if (comnt.Consulta!.IdPaciente == pac.IdPaciente)
                {
                    list.Add(comnt);
                }
            }
            return list;
        }

        public List<Comentario> ListarTodos()
        {
            return _context.Comentario.ToList();
        }
    }
}
