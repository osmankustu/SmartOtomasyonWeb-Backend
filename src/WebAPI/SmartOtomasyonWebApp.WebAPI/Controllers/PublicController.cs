using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartOtomasyonWebApp.Application.Features.PublicCommands;
using SmartOtomasyonWebApp.Application.Features.PublicQueries;
using SmartOtomasyonWebApp.Application.Features.PublicQueries.GetByIdQuery;
using SmartOtomasyonWebApp.Application.Features.Queries.PublicQueries;
using SmartOtomasyonWebApp.Application.Features.Queries.PublicQueries.GetByIdQuery;

namespace SmartOtomasyonWebApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PublicController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("home")]
        public async Task<IActionResult> GetAllHomePublic()
        {
            var query = new GetAllPublicHomeQuery();
            return Ok(await _mediator.Send(query));
        }


        [HttpGet("footer")]
        public async Task<IActionResult> GetAllFooterPublic()
        {
            var query = new GetAllPublicFooterQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("about")]
        public async Task<IActionResult> GetAllAboutPublic()
        {
            var query = new GetAllPublicAboutQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("imageCategory")]
        public async Task<IActionResult> GetAllImageCategoryPublic()
        {
            var query = new GetAllPublicImageCategoryQuery();
            return Ok(await _mediator.Send(query));
        }


        [HttpGet("image")]
        public async Task<IActionResult> GetAllImagePublic(int pageIndex=0,int pageSize=6)
        {
            var query = new GetAllPublicImageQuery() { PageIndex=pageIndex,PageSize=pageSize};
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("image/{id}")]
        public async Task<IActionResult> GetImageCategoryIdPublic(Guid id,int pageIndex=0,int pageSize=6)
        {
            var query = new GetByCategoryIdPublicImageQuery() { Id = id,PageIndex=pageIndex,PageSize=pageSize };
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("referance")]
        public async Task<IActionResult> GetAllPublic()
        {
            var query = new GetAllPublicReferanceQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("productCategory")]
        public async Task<IActionResult> GetAllProductCategoryPublic()
        {
            var query = new GetAllPublicProductCategoryQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetAllProductPublic(int pageIndex=0,int pageSize=6)
        {
            var query = new GetAllPublicProductQuery() { PageIndex=pageIndex,PageSize=pageSize};
            return Ok(await _mediator.Send(query)); 
        }

        [HttpGet("products/{id}")]
        public async Task<IActionResult> GetByIdProductPublic(Guid id)
        {
            var query = new GetByIdPublicProductQuery() { Id = id };
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("products/category/{id}")]
        public async Task<IActionResult> GetByCategoryIdProductPublic(Guid id,int pageIndex=0,int pageSize=6)
        {
            var query = new GetByCategoryIdPublicProductQuery() { Id = id,PageIndex=pageIndex,PageSize=pageSize };
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> addMail(CreateMailCommands command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("documentCategory")]
        public async Task<IActionResult> GetAllDocumentCategoryPublic()
        {
            var query = new GetAllPublicDocumentCategoryQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("document")]
        public async Task<IActionResult> GetAllDocumenPublic()
        {
            var query = new GetAllPublicDocumentQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("document/category/{id}")]
        public async Task<IActionResult> GetByCategoryIdPDocumentPublic(Guid id)
        {
            var query = new GetByCategoryIdDocumentQuery() { Id = id };
            return Ok(await _mediator.Send(query));
        }

    }
}
