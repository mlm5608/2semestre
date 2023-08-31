using System.Data.SqlClient;
using System.Runtime.Intrinsics.Arm;
using webapi.filmes.miguel.Domains;
using webapi.filmes.miguel.Interfaces;

namespace webapi.filmes.miguel.Repositores
{
    public class FilmeRepository : IFilmeRepository
    {
        private string StringConexao = "Data Source = NOTE06-S15; Initial Catalog = Filmes_Miguel; User Id = sa; Pwd = Senai@134";

        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryUpdate = "UPDATE Filme SET Titulo = (@novoTitulo), IdGenero = (@novoGenero) WHERE IdFilme = (@IdFilme)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", filme.IdFilme);
                    cmd.Parameters.AddWithValue("@novoTitulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@novoGenero", filme.IdGenero);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao)) 
            {
                string QueryUpdate = "UPDATE Filme SET Titulo = (@novoTitulo), IdGenero = (@novoGenero) WHERE IdFilme = (@IdFilme)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryUpdate, con)) 
                { 
                    cmd.Parameters.AddWithValue("@IdFilme", id);
                    cmd.Parameters.AddWithValue("@novoTitulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@novoGenero", filme.IdGenero);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FilmeDomain BuscarPorID(int id)
        {
            FilmeDomain filmeBuscado= new FilmeDomain(); 

            using(SqlConnection con = new SqlConnection(StringConexao)) 
            {
                string QuerySearch = "Select Filme.IdFilme, Filme.Titulo, Genero.IdGenero, Genero.Nome From Filme INNER join Genero ON Filme.IdGenero = Genero.IdGenero";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QuerySearch, con)) 
                {
                    SqlDataReader rdr;

                    cmd.Parameters.AddWithValue("@IdFilme", id);

                    cmd.ExecuteNonQuery();

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        filmeBuscado.IdFilme = Convert.ToInt32(rdr[0]);

                        filmeBuscado.Titulo = Convert.ToString(rdr["Titulo"]);

                        filmeBuscado.Genero = new GeneroDomain()
                        {
                            IdGenero = Convert.ToInt32(rdr[2]),

                            Nome = Convert.ToString(rdr["Nome"])
                        };
                    }
                }
            }
            return filmeBuscado;
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao)) 
            {
                string QueryInsert = "INSERT INTO Filme(IdGenero,Titulo) values (@IdGenero, @Titulo)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryInsert, con)) 
                {
                    cmd.Parameters.AddWithValue("@IdGenero", novoFilme.IdGenero);
                    cmd.Parameters.AddWithValue("@Titulo", novoFilme.Titulo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryDelete = "DELETE FROM Filme WHERE IdFilme = (@IdFilme)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryDelete,con )) 
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FilmeDomain> ListarTodos()
        {
            List<FilmeDomain> listaFilmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string todosFilmes = "Select Filme.IdFilme, Filme.Titulo, Genero.IdGenero, Genero.Nome From Filme INNER join Genero ON Filme.IdGenero = Genero.IdGenero";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(todosFilmes, con))
                {
                    rdr= cmd.ExecuteReader();

                    while (rdr.Read()) 
                    { 
                        FilmeDomain FilmeBuscado= new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),

                            Titulo = Convert.ToString(rdr["Titulo"]),

                            Genero = new GeneroDomain()
                            { 
                                IdGenero= Convert.ToInt32(rdr[2]),

                                Nome= Convert.ToString(rdr["Nome"])
                            }
                        };

                        listaFilmes.Add(FilmeBuscado);
                    }
                }
            }
            return listaFilmes;
        }
    }
}
