using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Commands.CreateUser
{
    public class CreateUserCommand: IRequest<int>
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        
    }
}
