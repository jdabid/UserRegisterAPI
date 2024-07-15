using System;

namespace ApiUserRegister.Models
{
    public class ResponseAuthentication
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
