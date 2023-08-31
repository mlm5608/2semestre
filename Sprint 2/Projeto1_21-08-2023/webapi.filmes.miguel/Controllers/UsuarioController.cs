using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.miguel.Domains;
using webapi.filmes.miguel.Interfaces;
using webapi.filmes.miguel.Repositores;

namespace webapi.filmes.miguel.Controllers

{       [Route("api/[controller]")]
        [ApiController]
        [Produces("application/json")]

    public class UsuarioController : ControllerBase
    {
       

        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
           _usuarioRepository= new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get(string email, string senha) 
        {
            try
            {
                UsuarioDomain usuarioLogado = _usuarioRepository.login(email, senha);

                if (usuarioLogado == null)
                {
                    return NotFound("Email ou senha incorretos!");
                }

                return StatusCode(200, $"Bem vindo a plataforma {usuarioLogado.Nome}!");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
