using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
            
        }
}
