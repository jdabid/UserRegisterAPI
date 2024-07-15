using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.UserFeatures.Commands.CreateUser;
using Application.Features.UserFeatures.Queries.GetUsers;
using Application.Features.UserFeatures.Commands.DeleteUser;
using Application.Features.UserFeatures.Commands.UpdateUser;


namespace ApiUserRegister.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController: ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost(Name = "CreateUser")]
        public async Task<ActionResult<int>> CreateUser(CreateUserCommand user)
        {
            var result = await mediator.Send(user);
            return result;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserVM>>> Get()
        {
            var result = await mediator.Send(new GetUsersQuery());
            return result;
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteUserCommand(id);
            var result = await mediator.Send(command);

            if (result == -1)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<UserUpdateVM>> Update([FromBody] UpdateUserCommand user, int id)
        {
            user.Id = id;
            var result = await mediator.Send(user);
            return result;
        }
            
    }
}
