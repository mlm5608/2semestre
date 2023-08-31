using System.Data.SqlClient;
using webapi.filmes.miguel.Domains;
using webapi.filmes.miguel.Interfaces;

namespace webapi.filmes.miguel.Repositores
{
    /// <summary>
    /// 
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {
        private string StringConexao = "Data Source = NOTE06-S15; Initial Catalog = Filmes_Miguel; User Id = sa; Pwd = Senai@134";

        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdate = "UPDATE Genero SET Nome = (@novoNome) WHERE IdGenero = (@id)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@novoNome", genero.Nome);
                    cmd.Parameters.AddWithValue("@id", genero.IdGenero);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdate = "UPDATE Genero SET Nome = (@novoNome) WHERE IdGenero = (@id)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@novoNome", genero.Nome);
                    cmd.Parameters.AddWithValue("@id", id);                
                    cmd.ExecuteNonQuery();
                }
            } 
        }

        public GeneroDomain BuscarPorID(int id)
        {
            GeneroDomain generoBuscado = new GeneroDomain();
            
            using (SqlConnection con = new SqlConnection(StringConexao))
            { 
                string querySearch = "SELECT * FROM Genero WHERE IdGenero = (@id)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(querySearch, con))
                {
                   SqlDataReader rdr; 
                    
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        generoBuscado.IdGenero = Convert.ToInt32(rdr[0]);

                        generoBuscado.Nome = Convert.ToString(rdr["Nome"]);
                    }
                }
            }
            return generoBuscado;
        }

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero"> Objeto com as novas informações que seráo cadastradas</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            //Declara a SQLConnection passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao)) 
            {
                //Declara a query que será executada
                string queryInsert = "INSERT INTO Genero(Nome) values (@Nome)";
          
                //Declara o SQL command  passando a query que será executada e a conexão com o bd
                using (SqlCommand cmd = new SqlCommand(queryInsert, con)) 
                {
                    //Passa o valor do parâmetro @Nome
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);
                    
                    //Abre a conexão com o banco de dados
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();                    
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            { 
                string queryDelete = "DELETE FROM Genero WHERE IdGenero = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    
                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<GeneroDomain> ListarTodos()
        {
            //Lista de gêneros instanciada onde serão armazenados os gêneros
            List<GeneroDomain> ListaGeneros = new List<GeneroDomain>();

            //Conexão com o banco de dados pelo System.Data.SqlClient - usando o using e o SqlConnection junto da string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Para usar scripts SQL coloco a instrução a ser executada em uma variável
                string todosGeneros = "SELECT IdGenero,Nome FROM Genero;";

                //Abre a conexão com o banco de dados
                con.Open();

                //Declara o SqlDatReader para percorrer(ler) os dados da tabela no banco de dados
                SqlDataReader rdr;

                //Recurso usado para executar o comando já estabelecido anteriormente usando a conexão já estabelecida anteriormente
                //Declara o SqlCommand passando o comando que será executado e a conexão com o banco de dados
                using (SqlCommand cmd = new SqlCommand(todosGeneros, con))
                {
                    //Executa de fato o comando e armazena os dados no leitor de dados (rdr)
                    rdr = cmd.ExecuteReader();

                    //Enquanto houver registros para serem lidos no rdr o laço se repetirá
                    while (rdr.Read())
                    {
                        GeneroDomain generoBuscado = new GeneroDomain()
                        {
                            //Atribui a propriedade IdGenero com o ou com o nome especificado da colunada da tabelal
                            //Usar o Convert.To para converter dados do rdr

                            //Aqui é por posição da coluna
                            IdGenero = Convert.ToInt32(rdr[0]),

                            //Aqui é por nome da coluna
                            Nome = Convert.ToString(rdr["Nome"])
                        };

                        ListaGeneros.Add(generoBuscado);
                    }
                }
                return ListaGeneros;
            }
        }

    }
}
