using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateWorkImage;
using SmartOtomasyonWebApp.Application.Features.Queries.GetWorkImageQueries.GetAllWorkImage;

namespace SmartOtomasyonWebApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkImagesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public WorkImagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllWorkImageQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateWorkImageCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

    }
}
