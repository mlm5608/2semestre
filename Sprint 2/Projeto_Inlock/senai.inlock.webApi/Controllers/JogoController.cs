using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;

namespace senai.inlock.webApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 
    [Produces("application/json")]
    public class JogoController : Controller
    {
        private IJogoRepository _jogoRepository { get; set; }

        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                List<JogoDomain> lista = _jogoRepository.ListarTodos();

                return Ok(lista);
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            };
        }

        [HttpPost]
        [Authorize(Roles = "2")]
        public IActionResult Post(JogoDomain novoJogo)
        {
            try
            {
                _jogoRepository.Cadastrar(novoJogo);
                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
