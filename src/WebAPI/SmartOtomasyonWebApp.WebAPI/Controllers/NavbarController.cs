using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateNavbar;
using SmartOtomasyonWebApp.Application.Features.Queries.GetNavbarCategory;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;

namespace SmartOtomasyonWebApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NavbarController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NavbarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllNavbarQuery();
            return Ok(await _mediator.Send(query));
           
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(CreateNavbarCommand Command)
        {
            return Ok(await _mediator.Send(Command));
        }
    }
}
