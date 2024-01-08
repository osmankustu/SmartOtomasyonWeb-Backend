using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartOtomasyonWebApp.Application.Dto;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateProduct;
using SmartOtomasyonWebApp.Application.Features.Commands.DeleteCommands.DeleteProduct;
using SmartOtomasyonWebApp.Application.Features.Commands.UpdateCommands.UpdateProduct;
using SmartOtomasyonWebApp.Application.Features.Queries.GetAllProducts;
using SmartOtomasyonWebApp.Application.Features.Queries.GetProductById;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;

namespace SmartOtomasyonWebApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllProductsQuery();
           return Ok(await _mediator.Send(query));
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getById(Guid id)
        {
            var query = new GetProductByIdQuery() { Id=id };
            return Ok(await _mediator.Send(query));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProductCommand() { Id = id };
            return Ok(await _mediator.Send(command));
        }
    }
}
