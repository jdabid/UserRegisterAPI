using Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Queries.IsValidUser
{
    public class IsUserValidHandler : IRequestHandler<IsUserValidQuery, bool>
    {
        private readonly IUserRepository userRepository;
        public IsUserValidHandler(IUserRepository _userRepository)
        {
            this.userRepository = _userRepository;
        }
        public async Task<bool> Handle(IsUserValidQuery request, CancellationToken cancellationToken)
        {
            var entities = await this.userRepository.GetAllAsync();

            var user = entities.Where(p => p.UserName == request.UserName && p.Password == request.Password).FirstOrDefault();
            var exists = user != null;
            return exists;
        }
    }
}
