using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source = NOTE06-S15; Initial Catalog = inlock_games_Miguel; User Id = sa; Pwd = Senai@134";

        public UsuarioDomain Login(string email, string senha)
        {
            UsuarioDomain usuarioLogado = new UsuarioDomain();

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryLogin = "SELECT * FROM Usuario WHERE Usuario.Email = (@Email) AND Usuario.Senha = (@Senha)";

                con.Open();

                using(SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    SqlDataReader rdr;

                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    rdr = cmd.ExecuteReader();

                    if(rdr.Read())
                    {
                        usuarioLogado.IdUsuario = Convert.ToInt32(rdr[0]);
                        usuarioLogado.IdTipoUsuario = Convert.ToInt32(rdr[1]);
                        usuarioLogado.Email = Convert.ToString(rdr[2]);
                        usuarioLogado.Senha = Convert.ToString(rdr[3]);

                        return usuarioLogado;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }
}
 