using Microsoft.AspNetCore.Mvc;
using webapi.event_.Domains;
using webapi.event_.Interfaces;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class ComentarioEventoController : ControllerBase
    {
        private IComentariosEventoRepository _comentarioEventoRepository { get; set; }

        public ComentarioEventoController()
        {
            _comentarioEventoRepository= new ComentariosEventoRepository();
        }

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                return Ok(_comentarioEventoRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id) 
        {
            try
            {
                return Ok(_comentarioEventoRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet("BuscarPorIdUsuario")]
        public IActionResult GetByUserId(Guid idUsuario, Guid idEvento) 
        {
            try
            {
                return Ok(_comentarioEventoRepository.BuscarPorIdUsuario(idUsuario, idEvento));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult post(ComentariosEvento comentario)
        {
            try
            {
                _comentarioEventoRepository.Cadastrar(comentario);
                return StatusCode(201, comentario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete]
        public IActionResult Delete(Guid id) 
        {
            try
            {
                _comentarioEventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message) /* StatusCode(204)*/;
            }
        }
    }
}
