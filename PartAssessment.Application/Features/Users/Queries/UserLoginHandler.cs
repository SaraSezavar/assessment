using MediatR;
using PartAssessment.Application.Extensions;
using PartAssessment.Application.Interfaces;
using PartAssessment.Common.Contracts;
using PartAssessment.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartAssessment.Application.Features.Users.Queries
{
    public class UserLoginHandler : IRequestHandler<UserLoginQuery, UserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenGenerator _tokenGenerator;

        public UserLoginHandler(IUserRepository userRepository, ITokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            this._tokenGenerator = tokenGenerator;
        }

        public async Task<UserResponse> Handle(UserLoginQuery request, CancellationToken cancellationToken)
        {
            var dbUser = await _userRepository.GetByUsername(request.Username);
            var userExists = dbUser?.Id > 0;
            var hashedPassword = request.Password.GetMd5Hash();

            if (!userExists || !dbUser.Password.Equals(hashedPassword))
                throw new ArgumentException("Username or password is incorrect.");

            var token = _tokenGenerator.GenerateToken(dbUser.Id);

            return new UserResponse(dbUser.Username, token);
        }
    }
}
