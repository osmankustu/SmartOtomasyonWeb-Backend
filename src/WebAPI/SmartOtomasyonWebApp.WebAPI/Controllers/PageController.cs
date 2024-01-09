using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateCommands.CreatePage;
using SmartOtomasyonWebApp.Application.Features.Commands.PageCommands;
using SmartOtomasyonWebApp.Application.Features.Queries.GetPageQueries;
using SmartOtomasyonWebApp.Application.Features.Queries.PublicQueries;

namespace SmartOtomasyonWebApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PageController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("public/{id}")]
        public async Task<IActionResult> PublicGetById(Guid id)
        {
            var query = new GetByIdPublicPageQuery(){Id = id };
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var command = new GetByIdPageQuery { Id = id };
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllPageQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeletePageCommand() { Id = id };
            return Ok(await _mediator.Send(command));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreatePageCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePageCommand command)
        {
            return Ok(await _mediator.Send(command));
        }



    }
}
