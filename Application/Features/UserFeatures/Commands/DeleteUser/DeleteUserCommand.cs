using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Commands.DeleteUser
{
    public class DeleteUserCommand: IRequest<int>
    {
        public int Id { get; set; }

        public DeleteUserCommand(int id)
        {
            this.Id = id;
            
        }
    }
}
