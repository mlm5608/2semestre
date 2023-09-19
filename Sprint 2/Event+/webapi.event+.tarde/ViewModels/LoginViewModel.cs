﻿using System.ComponentModel.DataAnnotations;

namespace webapi.event_.tarde.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email obrigatório")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatória")]
        public string? Senha { get; set; }
    }
}
