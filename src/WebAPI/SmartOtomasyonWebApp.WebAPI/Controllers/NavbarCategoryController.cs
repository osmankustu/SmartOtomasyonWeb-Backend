using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateNavbarCategory;
using SmartOtomasyonWebApp.Application.Features.Queries.GetNavbarCategoryQueries.GetAllNavbarCategory;

namespace SmartOtomasyonWebApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NavbarCategoryController : ControllerBase
    {
        private IMediator _mediator;
        public NavbarCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllNavbarCategoryQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateNavbarCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

    }
}
