using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateFooter;
using SmartOtomasyonWebApp.Application.Features.Commands.DeleteCommands.DeleteFooter;
using SmartOtomasyonWebApp.Application.Features.Commands.UpdateCommands.UpdateFooter;
using SmartOtomasyonWebApp.Application.Features.Queries.GetFooterQueries.GetAllFooter;
using SmartOtomasyonWebApp.Application.Features.Queries.GetFooterQueries.GetByIdFooter;

namespace SmartOtomasyonWebApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FooterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllFooterQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateFooterCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetByIdFooterQuery() { Id= id };
            return Ok(await _mediator.Send(query));
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateFooterCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Add(Guid id)
        {
            var command = new DeleteFooterCommand() { Id= id };
            return Ok(await _mediator.Send(command));
        }

    }
}
