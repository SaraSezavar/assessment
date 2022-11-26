using MediatR;
using PartAssessment.Application.Constants;
using PartAssessment.Application.Interfaces;
using PartAssessment.Common.Contracts;
using PartAssessment.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PartAssessment.Application.Features.Users.Queries.UserValidateToken
{
    public class UserValidateTokenHandler : IRequestHandler<UserValidateTokenQuery, UserResponse>
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IUserRepository _userRepository;

        public UserValidateTokenHandler(ITokenGenerator tokenGenerator, IUserRepository userRepository)
        {
            _tokenGenerator = tokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<UserResponse> Handle(UserValidateTokenQuery request, CancellationToken cancellationToken)
        {
            var isValid = _tokenGenerator.ValidateToken(request.Token);
            if (isValid)
            {
                var userId = Convert.ToInt32(_tokenGenerator.GetClaim(Claims.NameIdentifier, request.Token));
                var dbUser = await _userRepository.GetByIdAsync(userId);
                if (dbUser != null && dbUser.Id > 0)
                {
                    return new UserResponse(dbUser.Username, request.Token);
                }
            }

            return new UserResponse("", "");
        }
    }
}
