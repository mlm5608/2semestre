using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IJogoRepository
    {
        /// <summary>
        /// Cria um novo objeto e o adiciona ao BD.
        /// </summary>
        /// <param name="NovoJogo"> Objeto que será adicionado</param>
        void Cadastrar(JogoDomain NovoJogo);

        /// <summary>
        /// Lê e mostra todos os objetos cadastrados.
        /// </summary>
        /// <returns> Retorna a lista de objetos </returns>
        List<JogoDomain> ListarTodos();
    }
}
