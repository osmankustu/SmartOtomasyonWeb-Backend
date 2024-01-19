using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartOtomasyonWebApp.Application.Features.Queries.GetVisitorsQuery;

namespace SmartOtomasyonWebApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VisitorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllVisitorsQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("dashData")]
        public async Task<IActionResult> GetAllDashData()
        {
            var query = new GetDashboardQuery();
            return Ok(await _mediator.Send(query));
        }


    }
}
