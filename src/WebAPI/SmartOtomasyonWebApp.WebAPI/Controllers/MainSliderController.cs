using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartOtomasyonWebApp.Application.Features.Commands.MainSliderCommands;
using SmartOtomasyonWebApp.Application.Features.Queries.GetMainSliderQueries;

namespace SmartOtomasyonWebApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainSliderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MainSliderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllMainSliderQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var command = new GetByIdlMainSliderQuery() { Id = id };
            return Ok(await _mediator.Send(command));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateMainSliderCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateMainSliderCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteMainSliderCommand() { Id = id };
            return Ok(await _mediator.Send(command));
        }
    }
}
