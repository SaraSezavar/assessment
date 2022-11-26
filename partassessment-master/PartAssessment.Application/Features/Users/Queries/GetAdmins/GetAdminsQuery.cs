using MediatR;
using PartAssessment.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartAssessment.Application.Features.Users.Queries.GetAdmins
{
    public class GetAdminsQuery : IRequest<List<UserResponse>>
    {
        public GetAdminsQuery()
        {

        }
    }
}
