using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface ITipoEventoRepository
    {
        void Cadastrar(TipoEvento novoTipo);
        void Deletar(Guid id);
        List<TipoEvento> Listar();
        TipoEvento BuscarPorId(Guid id);
        void Atualizar(Guid id, TipoEvento tipoUsuario);
    }
}
