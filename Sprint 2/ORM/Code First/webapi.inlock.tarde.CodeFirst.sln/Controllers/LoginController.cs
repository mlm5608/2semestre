using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using webapi.inlock.tarde.CodeFirst.sln.Domains;
using webapi.inlock.tarde.CodeFirst.sln.Interfaces;
using webapi.inlock.tarde.CodeFirst.sln.Repositories;
using webapi.inlock.tarde.CodeFirst.sln.ViewModels;

namespace webapi.inlock.tarde.CodeFirst.sln.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]

        public IActionResult Login(LoginViewModel user)
        {
            try
            {
                UsuarioDomain usuario = _usuarioRepository.Login(user.Email!, user.Senha!);

                if (usuario == null)
                {
                    return StatusCode(401, "Email ou senha incorretos!");
                }
                else
                {
                    var Claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, usuario.IdUsuario.ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, usuario.Email!.ToString()),
                        new Claim(ClaimTypes.Role, usuario.IdTipoDeUsuario.ToString())
                    };
                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("WebApi-Autetication-CodeFirst"));

                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken
                    (
                    //emissor do token
                    issuer: "Webapi.Inlock.tarde.CodeFirst.sln",

                    //destinatario
                    audience: "Webapi.Inlock.tarde.CodeFirst.sln",

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
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
