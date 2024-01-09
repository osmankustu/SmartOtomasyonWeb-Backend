using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateCommands.CreateAuth;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateCommands.CreateUser;

namespace SmartOtomasyonWebApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Add(CreateUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Add(CreateLoginCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
