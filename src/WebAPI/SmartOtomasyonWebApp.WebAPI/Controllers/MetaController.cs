using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateCommands.CreateMeta;
using SmartOtomasyonWebApp.Application.Features.Commands.DeleteCommands.DeleteMeta;
using SmartOtomasyonWebApp.Application.Features.Commands.UpdateCommands;
using SmartOtomasyonWebApp.Application.Features.Queries.GetMetaQueries;

namespace SmartOtomasyonWebApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MetaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllMetaQuery();
            return Ok(await _mediator.Send(query));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetByIdMetaQuery() { Id=id};
            return Ok(await _mediator.Send(query));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteMetaCommand() { Id=id};
            return Ok(await _mediator.Send(command));
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateMetaCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateMetaCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
