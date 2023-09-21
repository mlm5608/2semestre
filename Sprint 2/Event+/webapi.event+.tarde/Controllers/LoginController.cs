using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;
using webapi.event_.tarde.ViewModels;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel user)
        {
            Usuario usuario = _usuarioRepository.BuscarPorEmailESenha(user.Email!, user.Senha!);

            if (usuario != null)
            {
                var Claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, usuario.IdUsuario.ToString()),
                        new Claim(JwtRegisteredClaimNames.Name, usuario.Nome!.ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, usuario.Email!.ToString()),
                        new Claim(ClaimTypes.Role, usuario.TipoUsuario!.Titulo!.ToString())
                    };
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("WebApi-Autetication-Event+-abcdefghijk"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                (
                //emissor do token
                issuer: "webapi.event+.tarde",

                //destinatario
                audience: "webapi.event+.tarde",

                //dados definidos nas claims
                claims: Claims,

                //tempo de expiração
                expires: DateTime.Now.AddMinutes(40),

                //Credenciais do token
                signingCredentials: creds
                );

                return StatusCode(200, new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            return null!;
        }
    }
}
