using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateCommands.CreatePhoneNumber;
using SmartOtomasyonWebApp.Application.Features.Commands.DeleteCommands.DeletePhoneNumber;
using SmartOtomasyonWebApp.Application.Features.Commands.UpdateCommands.UpdatePhoneNumber;
using SmartOtomasyonWebApp.Application.Features.Queries.GetPhoneNumberQueries.GetAllPhoneNumber;
using SmartOtomasyonWebApp.Application.Features.Queries.GetPhoneNumberQueries.GetByIdPhoneNumber;

namespace SmartOtomasyonWebApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllPhoneNumberQuery();
            return Ok(await _mediator.Send(query));
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreatePhoneNumberCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetByIdPhoneNumberQuery() { Id = id };
            return Ok(await _mediator.Send(query));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePhoneNumberCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeletePhoneNumberCommand() { Id = id };
            return Ok(await _mediator.Send(command));
        }
    }
}
