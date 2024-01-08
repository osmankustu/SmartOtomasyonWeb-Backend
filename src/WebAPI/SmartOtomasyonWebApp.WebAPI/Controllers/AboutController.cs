using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateAbout;
using SmartOtomasyonWebApp.Application.Features.Commands.DeleteCommands.DeleteAbout;
using SmartOtomasyonWebApp.Application.Features.Commands.UpdateCommands.UpdateAbout;
using SmartOtomasyonWebApp.Application.Features.Queries.GetAboutQueries.GetAllAbout;
using SmartOtomasyonWebApp.Application.Features.Queries.GetAboutQueries.GetByIdAAbout;
using SmartOtomasyonWebApp.Application.Features.Queries.PublicQueries;

namespace SmartOtomasyonWebApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AboutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllAboutQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var command = new GetByIdAboutQuery() { Id = id };
            return Ok(await _mediator.Send(command));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateAboutCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAboutCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteAboutCommand() { Id = id };
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("public")]
        public async Task<IActionResult> GetAllPublic()
        {
            var query = new GetAllPublicAboutQuery();
            return Ok(await _mediator.Send(query));
        }

    }
}
