using Application.Features.UserFeatures.Queries.GetUsers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Queries.IsValidUser
{
    public class IsUserValidQuery: IRequest<bool>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public IsUserValidQuery(string _userName, string _password)
        {
            this.UserName = _userName;
            this.Password = _password;
        }
    }
}
