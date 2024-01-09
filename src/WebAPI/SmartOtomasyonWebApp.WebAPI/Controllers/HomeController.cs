using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateCommands.CreateHome;
using SmartOtomasyonWebApp.Application.Features.Commands.HomeCommands;
using SmartOtomasyonWebApp.Application.Features.Queries.GetHomeQueries;

namespace SmartOtomasyonWebApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllHomeQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var command = new GetByIdHomeQuery() { Id = id };
            return Ok(await _mediator.Send(command));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateHomeCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateHomeCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteHomeCommand() { Id = id };
            return Ok(await _mediator.Send(command));
        }
    }
}
