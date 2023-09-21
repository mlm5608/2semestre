using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencaEventoController : ControllerBase
    {
        private readonly IPresencaEventoRepository _PresencaEventoRepository;

        public PresencaEventoController()
        {
            _PresencaEventoRepository = new PresencaEventoRepository();
        }

        [HttpPost]
        public IActionResult Post(PresencaEvento presenca)
        {
            try
            {
                _PresencaEventoRepository.Cadastrar(presenca);
                return Ok(presenca);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_PresencaEventoRepository.Listar());
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
                _PresencaEventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_PresencaEventoRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public IActionResult Put(Guid id, PresencaEvento presenca)
        {
            try
            {
                _PresencaEventoRepository.Atualizar(id, presenca);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListarMinhas")]
        public IActionResult GetMy(Guid id) 
        { 
            return Ok(_PresencaEventoRepository.ListarMinhas(id));
        }
    }
}
