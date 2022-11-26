using MediatR;
using PartAssessment.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartAssessment.Application.Features.Users.Queries.UserValidateToken
{
    public class UserValidateTokenQuery: IRequest<UserResponse>
    {
        public UserValidateTokenQuery(string token)
        {
            Token = token;
        }

        public string Token { get; }
    }
}
