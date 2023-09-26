using webapi.healthClinic.miguel.Domains;

namespace webapi.healthClinic.miguel.Interfaces
{
    public interface IPacienteRepository
    {
        void Cadastrar(Paciente p);
        List<Paciente> ListarTodos();
        void Deletar(Guid id);
        Paciente BuscarPorId(Guid id);
        void Atualizar(Paciente p, Guid id);
    }
}
