using System.Data.SqlClient;
using webapi.filmes.miguel.Domains;
using webapi.filmes.miguel.Interfaces;

namespace webapi.filmes.miguel.Repositores
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source = NOTE06-S15; Initial Catalog = Filmes_Miguel; User Id = sa; Pwd = Senai@134";

        public UsuarioDomain login(string email, string senha)
        {
            UsuarioDomain userLogado = new UsuarioDomain();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryLogin = "SELECT * FROM Usuario WHERE Usuario.Email = (@email) AND Usuario.Senha = (@senha)";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    SqlDataReader rdr;

                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    { 
                        userLogado.IdUsuario = Convert.ToInt32(rdr[0]);
                        userLogado.Nome = Convert.ToString(rdr[1]);
                        userLogado.Email = Convert.ToString(rdr[2]);
                        userLogado.Senha = Convert.ToString(rdr[3]);
                        userLogado.Permissao = Convert.ToBoolean(rdr[4]);

                        return userLogado;
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
