using Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int>
    {

        private readonly IUserRepository userRepository;
        public DeleteUserCommandHandler(IUserRepository _userRepository)
        {
            this.userRepository = _userRepository;
        }

        public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {

            var entity = await this.userRepository.GetByIdAsync(request.Id);

            if(entity == null)
            {
                return -1;
            }

            await this.userRepository.DeleteAsync(entity);
            
            return entity.Id;
        }
    }
}
