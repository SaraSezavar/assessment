using MediatR;
using PartAssessment.Common.Contracts;
using PartAssessment.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartAssessment.Application.Features.Users.Queries.GetAdmins
{
    public class GerAdminsHandler : IRequestHandler<GetAdminsQuery, List<UserResponse>>
    {
        private readonly IUserRepository _userRepository;

        public GerAdminsHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserResponse>> Handle(GetAdminsQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetByRole("Admin");
            var result = new List<UserResponse>();
            if (users != null && users.Count > 0)
            {
                foreach (var item in users)
                {
                    result.Add(new UserResponse(item.Username, ""));
                }
            }

            return result;
        }
    }
}
