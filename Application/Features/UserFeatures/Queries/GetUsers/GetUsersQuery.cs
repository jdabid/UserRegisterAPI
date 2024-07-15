using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<List<UserVM>>
    {
        public GetUsersQuery()
        {
            
        }
    }
}
