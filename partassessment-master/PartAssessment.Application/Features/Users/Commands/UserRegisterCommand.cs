using MediatR;
using PartAssessment.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartAssessment.Application.Features.Users.Commands
{
    public class UserRegisterCommand: IRequest<UserResponse>
    {
        public UserRegisterCommand(string firstname, string lastname, string username, string password)
        {
            Firstname = firstname;
            Lastname = lastname;
            Username = username;
            Password = password;
        }

        public string Firstname { get; }
        public string Lastname { get; }
        public string Username { get; }
        public string Password { get; }
    }
}
