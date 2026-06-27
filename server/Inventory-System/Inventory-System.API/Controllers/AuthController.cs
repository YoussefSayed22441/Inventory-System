using Inventory_System.Core.Features.Users.Commands.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_System.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : BaseApiController
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState); 

            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var response = await _mediator.Send(command);
            return NewResult(response);
        }


        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
        {

            var response = await _mediator.Send(command);
            return NewResult(response);
        }
    }
}
