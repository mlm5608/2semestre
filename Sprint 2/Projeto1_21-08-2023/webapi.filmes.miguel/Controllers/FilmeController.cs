using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.miguel.Domains;
using webapi.filmes.miguel.Interfaces;
using webapi.filmes.miguel.Repositores;

namespace webapi.filmes.miguel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]//precisa estar logado para acessar a rota
    [Produces("application/json")]
    public class FilmeController : ControllerBase
    {
        private IFilmeRepository _filmeRepository { get; set; }

        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<FilmeDomain> filmes = _filmeRepository.ListarTodos();

                return Ok(filmes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(FilmeDomain nFilme)
        {
            try
            {
                _filmeRepository.Cadastrar(nFilme);
                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            try
            {
                _filmeRepository.Deletar(Id);
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
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorID(id);

                if (filmeBuscado.IdFilme == null)
                {
                    return NotFound("O filme escolhido não foi encontrado");
                }

                return Ok(filmeBuscado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateURL(int id, FilmeDomain filme)
        {
            try
            {
                _filmeRepository.AtualizarIdUrl(id, filme);

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public IActionResult UpdateBody(FilmeDomain filme)
        {
            try
            {
                _filmeRepository.AtualizarIdCorpo(filme);

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
