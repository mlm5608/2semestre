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
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorID(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(GeneroDomain novoGenero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
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
