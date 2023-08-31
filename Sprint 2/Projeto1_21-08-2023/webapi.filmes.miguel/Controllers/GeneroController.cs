using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.miguel.Domains;
using webapi.filmes.miguel.Interfaces;
using webapi.filmes.miguel.Repositores;

namespace webapi.filmes.miguel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Produces("application/json")]
    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// Endpoint que acessa o metodo de listar os generos
        /// </summary>
        /// <returns>Lista de generos e um statuscode</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Cria uma lista para receber os generos.
                List<GeneroDomain> ListaGeneros = _generoRepository.ListarTodos();

                //Retorna o status code 200 e a listagem dos generos no formato JSON
                return Ok(ListaGeneros);
            }
            catch (Exception ex)
            {
                //Retuorna um status code 400 e a mensagem de erro
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(GeneroDomain nGenero)
        {
            try
            {
                //Chama o metodo e cadastra o novo genero recebido
                _generoRepository.Cadastrar(nGenero);

                //Retorna o status code 
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                //Retuorna um status code 400 e a mensagem de erro
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _generoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Search(int id)
        {
            try
            {
                GeneroDomain GeneroBuscado = _generoRepository.BuscarPorID(id);

                if ((GeneroBuscado.Nome == null) && (GeneroBuscado.IdGenero == 0))
                {
                    return NotFound("O gênero buscado não foi encontrado!");
                }

                return StatusCode(200, GeneroBuscado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateURL(int id, GeneroDomain genero)
        {
            try
            {
                _generoRepository.AtualizarIdUrl(id, genero);

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public IActionResult UpdateBody(GeneroDomain genero)
        {
            try
            {
                _generoRepository.AtualizarIdCorpo(genero);

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    
    }
}
