using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateProductCategory;
using SmartOtomasyonWebApp.Application.Features.Commands.ProductCategoryCommands;
using SmartOtomasyonWebApp.Application.Features.Queries.GetProductCategoryQueries;
using SmartOtomasyonWebApp.Application.Features.Queries.PublicQueries;
using SmartOtomasyonWebApp.Application.Features.Queries.PublicQueries.GetByIdQuery;

namespace SmartOtomasyonWebApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllProductCategoryQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateProductCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetByIdProductCategoryQuery() { Id = id };
            return Ok(await _mediator.Send(query));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProductCategoryCommand() { Id = id };
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }



    }
}
