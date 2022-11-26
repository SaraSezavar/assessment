using MediatR;
using PartAssessment.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartAssessment.Application.Features.Users.Queries
{
    public class UserLoginQuery : IRequest<UserResponse>
    {
        public UserLoginQuery(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; }
        public string Password { get; }
    }
}
