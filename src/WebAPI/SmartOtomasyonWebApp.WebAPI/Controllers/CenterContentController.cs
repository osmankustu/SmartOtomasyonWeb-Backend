using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartOtomasyonWebApp.Application.Features.Commands.CenterContentCommands;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateCommands.CreateCenterContent;
using SmartOtomasyonWebApp.Application.Features.Queries.GetCenterContentQueries;

namespace SmartOtomasyonWebApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CenterContentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CenterContentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllCenterContentQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var command = new GetByIdCenterContentQuery() { Id = id };
            return Ok(await _mediator.Send(command));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateCenterContentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCenterContentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteCenterContentCommand() { Id = id };
            return Ok(await _mediator.Send(command));
        }


    }
}
