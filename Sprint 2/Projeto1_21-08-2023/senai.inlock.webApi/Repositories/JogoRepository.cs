using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string StringConexao = "Data Source = NOTE06-S15; Initial Catalog = inlock_games_Miguel; User Id = sa; Pwd = Senai@134";
        public void Cadastrar(JogoDomain NovoJogo)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "INSERT INTO Jogo VALUES (@IdEstudio, @Nome, @Descricao, @Data, @Preco)";
                con.Open();
                
            }
        }

        public List<JogoDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
