using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai.inlock.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }
        
        [HttpPut]
        public IActionResult Put(UsuarioDomain usuario)
        {
            try
            {
                UsuarioDomain usuarioLogado = _usuarioRepository.Login(usuario.Email, usuario.Senha);

                if (usuarioLogado == null) 
                {
                    return NotFound("Email ou Senha Incorretos!");
                }

                var Claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioLogado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioLogado.Email.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioLogado.IdTipoUsuario.ToString()),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao-webApi-dev"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                (
                    //emissor do token
                    issuer: "senai.Inlock.webApi",

                    //destinatario
                    audience: "senai.Inlock.webApi",

                    //dados definidos nas claims
                    claims: Claims,

                    //tempo de expiração
                    expires: DateTime.Now.AddMinutes(5),

                    //Credenciais do token
                    signingCredentials: creds
                );

                return StatusCode(200, new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

        }
    }
}
