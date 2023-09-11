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

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", NovoJogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@Nome", NovoJogo.Nome);
                    cmd.Parameters.AddWithValue("@Descricao", NovoJogo.descricao);
                    cmd.Parameters.AddWithValue("@Data", NovoJogo.DataDeLançamento);
                    cmd.Parameters.AddWithValue("@Preco", NovoJogo.Preco);

                    cmd.ExecuteNonQuery();
                }
                
            }
        }

        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> listaJogos = new List<JogoDomain>();

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT Jogo.IdJogo, Jogo.Nome, Estudio.IdEstudio, Estudio.Nome, Jogo.Descricao, Jogo.DataLancamento, Jogo.Valor FROM Jogo INNER JOIN Estudio ON Estudio.IdEstudio = Jogo.IdEstudio";

                con.Open();

                SqlDataReader rdr;

                using(SqlCommand cmd = new SqlCommand(query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr[0]),
                            Nome = Convert.ToString(rdr[1]),
                            Estudio = new EstudioDomain
                            {
                                IdEstudio = Convert.ToInt32(rdr[2]),
                                NomeEstudio = Convert.ToString(rdr[3])
                            },
                            descricao = Convert.ToString(rdr[4]),
                            DataDeLançamento = Convert.ToDateTime(rdr[5]),
                            Preco = Convert.ToDecimal(rdr[6])
                        };
                        listaJogos.Add(jogo);
                    }
                }
            }
            return listaJogos;
        }
    }
}
