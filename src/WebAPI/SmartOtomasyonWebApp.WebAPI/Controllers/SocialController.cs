using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateSocialLink;
using SmartOtomasyonWebApp.Application.Features.Commands.DeleteCommands.DeleteSocialLink;
using SmartOtomasyonWebApp.Application.Features.Commands.UpdateCommands.UpdateSocialLink;
using SmartOtomasyonWebApp.Application.Features.Queries.GetSocialLinksQueries.GetAllSocialLinks;
using SmartOtomasyonWebApp.Application.Features.Queries.GetSocialLinksQueries.GetByIdSocialLink;

namespace SmartOtomasyonWebApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SocialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllSocialLinkQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateSocialLinkCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetByIdSocialLinkQuery() { Id = id };
            return Ok(await _mediator.Send(query));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateSocialLinkCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteSocialLinkCommand() { Id = id };
            return Ok(await _mediator.Send(command));
        }

    }
}
