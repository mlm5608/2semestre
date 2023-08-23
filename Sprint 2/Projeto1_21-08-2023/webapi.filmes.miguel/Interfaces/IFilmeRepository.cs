using webapi.filmes.miguel.Domains;

namespace webapi.filmes.miguel.Interfaces
{
    public interface IFilmeRepository
    {
        //TipoDeRetorno NomeMetodo (TipoParametro NomeParametros)
        /// <summary>
        /// Cadatra um novo genero 
        /// </summary>
        /// <param name="novoFilme">Objeto que será cadastrado</param>
        void Cadastrar(FilmeDomain novoFilme);

        /// <summary>
        /// Retorna todos os generos cadastrados
        /// </summary>
        /// <returns>Uma lista de generos (Objetos)</returns>
        List<FilmeDomain> ListarTodos();

        /// <summary>
        /// Buscar um objeto atravéz do seu id 
        /// </summary>
        /// <param name="id">id do objeto a ser busado</param>
        /// <returns>Objeto que foi buscado</returns>
        FilmeDomain BuscarPorID(int id);

        /// <summary>
        /// Atualiza um genero existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto que conterá as novas infos</param>
        void AtualizarIdCorpo(FilmeDomain filme);

        /// <summary>
        /// Atualiza um genero existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="id">id do objeto a ser atualizado</param>
        /// <param name="genero">Objeto com as novas informações</param>
        void AtualizarIdUrl(int id, FilmeDomain filme);

        /// <summary>
        /// Deleta um genero existente
        /// </summary>
        /// <param name="id">Id do objeto a ser deletado</param>
        void Deletar(int id);

    }
}
