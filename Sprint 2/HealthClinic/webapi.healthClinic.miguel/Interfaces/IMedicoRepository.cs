using webapi.healthClinic.miguel.Domains;

namespace webapi.healthClinic.miguel.Interfaces
{
    public interface IMedicoRepository
    {
        void Cadastrar(Medico m);
        List<Medico> ListarTodos();
        void Deletar(Guid id);
        Medico BuscarPorId(Guid id);
        void Atualizar(Medico m, Guid id);
    }
}
