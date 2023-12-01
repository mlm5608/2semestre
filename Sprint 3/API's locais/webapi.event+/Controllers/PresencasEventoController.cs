using Microsoft.AspNetCore.Mvc;
using webapi.event_.Domains;
using webapi.event_.Interfaces;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencasEventoController : ControllerBase
    {
        private IPresencasEventoRepository _presencaEventoRepository { get; set; }
        public PresencasEventoController()
        {
            _presencaEventoRepository = new PresencaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_presencaEventoRepository.Listar());
            }
            catch (Exception e )
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(PresencasEvento pe)
        {
            try
            {
                _presencaEventoRepository.Inscrever(pe);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListarMinhas/{id}")]

        public IActionResult getMyList(Guid id)
        {
            try
            {
                
                return Ok(_presencaEventoRepository.ListarMinhas(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
