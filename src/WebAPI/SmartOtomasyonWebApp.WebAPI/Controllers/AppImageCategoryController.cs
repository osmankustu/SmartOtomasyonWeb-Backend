using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateWorkImageCategory;
using SmartOtomasyonWebApp.Application.Features.Commands.DeleteCommands.DeleteWorkImageCategory;
using SmartOtomasyonWebApp.Application.Features.Commands.UpdateCommands.UpdateWorkImageCategory;
using SmartOtomasyonWebApp.Application.Features.Queries.GetWorkImageCategoryQueries.GetAllWorkImageCategory;
using SmartOtomasyonWebApp.Application.Features.Queries.GetWorkImageCategoryQueries.GetByIdWorkImageCategory;

namespace SmartOtomasyonWebApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppImageCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AppImageCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllWorkImageCategoryQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetByIdWorkImageCategoryQuery() { Id = id };
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateWorkImageCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateWorkImageCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
           var command = new DeleteWorkImageCategoryCommand() { Id = id };
            return Ok(await _mediator.Send(command));
        }
    }
}
