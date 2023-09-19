using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        void Cadastrar(TipoUsuario novoTipo);
        void Deletar(Guid id);
        List<TipoUsuario> Listar();
        TipoUsuario BuscarPorId(Guid id); 
        void Atualizar(Guid id, TipoUsuario tipoUsuario);
    }
}
