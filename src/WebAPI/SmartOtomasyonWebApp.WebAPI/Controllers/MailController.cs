using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartOtomasyonWebApp.Application.Features.Commands.AboutCommands;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateAbout;
using SmartOtomasyonWebApp.Application.Features.Commands.MailCommands;
using SmartOtomasyonWebApp.Application.Features.Queries.GetAboutQueries;
using SmartOtomasyonWebApp.Application.Features.Queries.GetMailQueries;

namespace SmartOtomasyonWebApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllMailQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var command = new GetByIdMailQuery() { Id = id };
            return Ok(await _mediator.Send(command));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteMailCommand() { Id = id };
            return Ok(await _mediator.Send(command));
        }
    }
}
