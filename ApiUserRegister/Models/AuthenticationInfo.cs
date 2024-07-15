using System;
using System.ComponentModel.DataAnnotations;

namespace ApiUserRegister.Models
{
    public class AuthenticationInfo
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]        
        public string UserName { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Password { get; set; }
    }
}
