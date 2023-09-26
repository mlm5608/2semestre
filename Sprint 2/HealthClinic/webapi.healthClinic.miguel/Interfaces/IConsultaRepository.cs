using webapi.healthClinic.miguel.Domains;

namespace webapi.healthClinic.miguel.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta c);
        List<Consulta> ListarTodos(); //somente ADM
        List<Consulta> ListarMinhasMedico();//Somente medicos
        List<Consulta> ListarMinhasPaciente();//Soemnte pacientes
        void Deletar(Guid id);
        Comentario BuscarPorId(Guid id);
        void Atualizar(Consulta c, Guid id);
    }
}
