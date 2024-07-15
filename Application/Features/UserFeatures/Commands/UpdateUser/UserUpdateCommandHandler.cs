using Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Commands.UpdateUser
{
    public class UserUpdateCommandHandler : IRequestHandler<UpdateUserCommand, UserUpdateVM>
    {
        private readonly IUserRepository userRepository;
        public UserUpdateCommandHandler(IUserRepository _userRepository)
        {
            this.userRepository = _userRepository;
            
        }
        public async Task<UserUpdateVM> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await this.userRepository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new Exception();
            }

            entity.Name = request.Name;
            entity.Password = request.Password;

            await this.userRepository.UpdateAsync(entity);

            var userUpdateVM = new UserUpdateVM();
            userUpdateVM.Id = entity.Id;
            userUpdateVM.Name = entity.Name;
            userUpdateVM.UserName = entity.UserName;

            return userUpdateVM;
           
        }
    }
}
