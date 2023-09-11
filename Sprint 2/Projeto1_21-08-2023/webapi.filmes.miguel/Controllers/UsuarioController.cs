using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.filmes.miguel.Domains;
using webapi.filmes.miguel.Interfaces;
using webapi.filmes.miguel.Repositores;

namespace webapi.filmes.miguel.Controllers
{       
        [Route("api/[controller]")]
        [ApiController]
        [Produces("application/json")]

    public class UsuarioController : ControllerBase
    {
       

        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
           _usuarioRepository= new UsuarioRepository();
        }

        [HttpPut]
        public IActionResult Put(UsuarioDomain usuario) 
        {
            try
            {
                UsuarioDomain usuarioLogado = _usuarioRepository.login(usuario.Email, usuario.Senha);

                if (usuarioLogado == null)
                {
                    return NotFound("Email ou senha incorretos!");
                }

                //Caso encontre o usuario, prossegue para a criação do token

                //1° - dados que serão fornecidos pelo token (payload)
                var claims = new[]
                {
                    //formato da claim (tipo, valor)
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioLogado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioLogado.Email.ToString()),
                    new Claim(ClaimTypes.Role, usuarioLogado.Permissao.ToString()),
                    //Existe a possiblidade que criar uma claim personalizada
                    //new Claim("Claim Personalizada", "Valor Personalizado")
                };

                //2° - Definir a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("flmes-chave-autenticacao-webapi-dev"));

                //3° - Definir as credenciais do token(Header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4° - Gerar o token 
                var token = new JwtSecurityToken
                (
                    //emissor do token
                    issuer: "webapi.filmes.miguel",
                    
                    //destinatario
                    audience: "webapi.filmes.miguel",

                    //dados definidos nas claims
                    claims: claims,

                    //tempo de expiração
                    expires: DateTime.Now.AddMinutes(5),

                    //Credenciais do token
                    signingCredentials: creds
                );
                //5° retornar o token criado

                //Return ok
                return StatusCode(200, new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
