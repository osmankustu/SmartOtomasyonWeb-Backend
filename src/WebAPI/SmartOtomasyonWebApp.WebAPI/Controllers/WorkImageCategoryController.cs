using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateWorkImageCategory;
using SmartOtomasyonWebApp.Application.Features.Queries.GetWorkImageCategoryQueries.GetAllWorkImageCategory;

namespace SmartOtomasyonWebApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkImageCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public WorkImageCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllWorkImageCategoryQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateWorkImageCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
