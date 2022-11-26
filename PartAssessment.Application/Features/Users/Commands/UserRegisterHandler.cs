using MediatR;
using PartAssessment.Application.Extensions;
using PartAssessment.Application.Interfaces;
using PartAssessment.Common.Contracts;
using PartAssessment.Domain.Entities;
using PartAssessment.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartAssessment.Application.Features.Users.Commands
{
    public class UserRegisterHandler : IRequestHandler<UserRegisterCommand, UserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenGenerator _tokenGenerator;

        public UserRegisterHandler(IUserRepository userRepository, ITokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<UserResponse> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            //Guards
            var dbUser = await _userRepository.GetByUsername(request.Username);
            var userExists = dbUser?.Id > 0;

            if (userExists)
                throw new ArgumentException("Username is not accepted. Change it please.");

            var hashedPassword = request.Password.GetMd5Hash();
            var entity = User.GetInstance(request.Firstname, request.Lastname, request.Username, hashedPassword, null);
            var result = await _userRepository.AddAsync(entity);
            var token = _tokenGenerator.GenerateToken(result.Id);

            return new UserResponse(result.Username, token);
        }
    }
}
