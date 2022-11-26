using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PartAssessment.Application.Features.Users.Commands;
using PartAssessment.Application.Features.Users.Queries;
using PartAssessment.Application.Features.Users.Queries.GetAdmins;
using PartAssessment.Application.Features.Users.Queries.UserValidateToken;
using PartAssessment.Common.Contracts;

namespace PartAssessment.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterRequest request)
        {
            var command = new UserRegisterCommand(request.FirstName, request.LastName, request.Username, request.Password);
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            var query = new UserLoginQuery(request.Username, request.Password);
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet("validateToken/{token}")]
        public async Task<IActionResult> ValidateToken([FromRoute] string token)
        {
            var query = new UserValidateTokenQuery(token);
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet("admins")]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<ActionResult<List<UserResponse>>> GetAdmins()
        {
            var query = new GetAdminsQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }

    }
}
