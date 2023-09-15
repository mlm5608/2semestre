using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace webapi.inlock.tarde.CodeFirst.sln.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email obrigatório")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatória")]
        public string? Senha { get; set; }
    }
}
