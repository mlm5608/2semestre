using webapi.filmes.miguel.Domains;

namespace webapi.filmes.miguel.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório GeneroRepository
    /// Define os métodos que serão implementados pelo repositório
    /// </summary>
    public interface IGeneroRepository
    {
        //CRUD

        //TipoDeRetorno NomeMetodo (TipoParametro NomeParametros)
        /// <summary>
        /// Cadatra um novo genero 
        /// </summary>
        /// <param name="novoGenero">Objeto que será cadastrado</param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Retorna todos os generos cadastrados
        /// </summary>
        /// <returns>Uma lista de generos (Objetos)</returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Buscar um objeto atravéz do seu id 
        /// </summary>
        /// <param name="id">id do objeto a ser busado</param>
        /// <returns>Objeto que foi buscado</returns>
        GeneroDomain BuscarPorID(int id);

        /// <summary>
        /// Atualiza um genero existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto que conterá as novas infos</param>
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualiza um genero existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="id">id do objeto a ser atualizado</param>
        /// <param name="genero">Objeto com as novas informações</param>
        void AtualizarIdUrl(int id,GeneroDomain genero);

        /// <summary>
        /// Deleta um genero existente
        /// </summary>
        /// <param name="id">Id do objeto a ser deletado</param>
        void Deletar(int id);

    }
}
