﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetAllImagePublic()
        {
            var query = new GetAllPublicImageQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("image/{id}")]
        public async Task<IActionResult> GetImageCategoryIdPublic(Guid id)
        {
            var query = new GetByCategoryIdPublicImageQuery() { Id = id };
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
        public async Task<IActionResult> GetAllProductPublic()
        {
            var query = new GetAllPublicProductQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("products/{id}")]
        public async Task<IActionResult> GetByIdProductPublic(Guid id)
        {
            var query = new GetByIdPublicProductQuery() { Id = id };
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("products/category/{id}")]
        public async Task<IActionResult> GetByCategoryIdProductPublic(Guid id)
        {
            var query = new GetByCategoryIdPublicProductQuery() { Id = id };
            return Ok(await _mediator.Send(query));
        }
    }
}
