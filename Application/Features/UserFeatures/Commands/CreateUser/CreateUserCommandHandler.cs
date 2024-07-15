using MediatR;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts;

namespace Application.Features.UserFeatures.Commands.CreateUser
{
    public class CreateUserCommandHandler: IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository userRepository;
        //private readonly IMapper mapper;

        public CreateUserCommandHandler(IUserRepository _userRepository)
        {
            this.userRepository = _userRepository;
        //    //this.mapper = mapper;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User();
            user.Name = request.Name;
            user.UserName = request.UserName;
            user.Password = request.Password;

            var newUser = await userRepository.AddAsync(user);
            return newUser.Id;
        }
    }
}
