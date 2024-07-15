using Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Queries.GetUsers
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, List<UserVM>>
    {
        private readonly IUserRepository userRepository;
        public GetUsersHandler(IUserRepository _userRepository)
        {
            this.userRepository = _userRepository;
        }
        public async Task<List<UserVM>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var entities = await this.userRepository.GetAllAsync();

            var res = new List<UserVM>();
            
            foreach (var entity in entities) { 
                var uVM= new UserVM();
                uVM.Id = entity.Id;
                uVM.Name = entity.Name;
                uVM.Username = entity.UserName;
                res.Add(uVM);
            }

            return res;
        }
    }
}
