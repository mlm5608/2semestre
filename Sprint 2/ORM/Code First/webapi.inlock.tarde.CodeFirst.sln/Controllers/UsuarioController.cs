using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock.tarde.CodeFirst.sln.Domains;
using webapi.inlock.tarde.CodeFirst.sln.Interfaces;
using webapi.inlock.tarde.CodeFirst.sln.Repositories;

namespace webapi.inlock.tarde.CodeFirst.sln.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(UsuarioDomain user)
        {
            try
            {
                _usuarioRepository.Cadastrar(user);

                return StatusCode(200, user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        }
    }
}
