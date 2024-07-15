using System;
using System.ComponentModel.DataAnnotations;

namespace ApiUserRegister.Models
{
    public class AuthenticationInfo
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Password { get; set; }
    }
}
