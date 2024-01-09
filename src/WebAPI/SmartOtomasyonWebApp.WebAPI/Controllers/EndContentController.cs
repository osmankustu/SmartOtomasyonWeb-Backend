using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartOtomasyonWebApp.Application.Features.Commands.EndContentCommands;
using SmartOtomasyonWebApp.Application.Features.Queries.GetEndContentQueries;

namespace SmartOtomasyonWebApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EndContentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EndContentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllEndContentQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var command = new GetByIdEndContentQuery() { Id = id };
            return Ok(await _mediator.Send(command));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateEndContentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateEndContentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteEndContentCommand() { Id = id };
            return Ok(await _mediator.Send(command));
        }


    }
}
