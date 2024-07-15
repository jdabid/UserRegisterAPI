using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiUserRegister.Models;
using Application.Features.UserFeatures.Queries.GetUsers;
using Application.Features.UserFeatures.Queries.IsValidUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Scheduling.API.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IMediator mediator;

        public LoginController(IConfiguration configuration, IMediator mediator)
        {
            this.configuration = configuration;
            this.mediator = mediator;
        }

        [HttpPost()]
        public async Task<ActionResult<ResponseAuthentication>> Login([FromBody] AuthenticationInfo authenticationInfo)
        {
            try
            {
                var query = new IsUserValidQuery(authenticationInfo.UserName, authenticationInfo.Password);
                var result = await mediator.Send(query);

                if (!result)
                {
                    return BadRequest("Login");
                }

                var claims = new List<Claim>();
                claims.Add(new Claim("username", authenticationInfo.UserName));
                return BuildToken(authenticationInfo, claims);
            }
            catch (ApplicationException ex)
            {
                var message = new
                {
                    message = ex.Message
                };
                return Unauthorized(message);
            }
            catch (Exception ex)
            {
                var message = new
                {
                    message = ex.Message
                };
                return BadRequest(message);
            }
        }

        private ResponseAuthentication BuildToken(AuthenticationInfo authenticationInfo, List<Claim> claims)
        {            
            var keyjwt = this.configuration["keyjwt"] ?? string.Empty;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyjwt));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var espiration = DateTime.UtcNow.AddYears(1);

            var token = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: espiration,
                signingCredentials: creds);

            return new ResponseAuthentication()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = espiration
            };
        }

        [HttpGet]
        [Route("/ValidateService")]
        public string ValidateService()
        {
            return "listening";
        }
    }
}