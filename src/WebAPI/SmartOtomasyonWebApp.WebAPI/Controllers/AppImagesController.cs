﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateWorkImage;
using SmartOtomasyonWebApp.Application.Features.Commands.DeleteCommands.DeleteWorkImages;
using SmartOtomasyonWebApp.Application.Features.Commands.UpdateCommands.UpdateWorkImage;
using SmartOtomasyonWebApp.Application.Features.Queries.GetWorkImageQueries.GetAllWorkImage;
using SmartOtomasyonWebApp.Application.Features.Queries.GetWorkImageQueries.GetByCategoryIdImage;
using SmartOtomasyonWebApp.Application.Features.Queries.GetWorkImageQueries.GetByIdWorkImage;

namespace SmartOtomasyonWebApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppImagesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AppImagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllWorkImageQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetByIdWorkImageQuery() { Id = id };
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("categoryId/{id}")]
        public async Task<IActionResult> GetByCategoryId(Guid id)
        {
            var query = new GetByCategoryIdImageQuery() { categoryId = id };
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateWorkImageCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateWorkImageCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteWorkImagesCommand() { Id = id };
            return Ok(await _mediator.Send(command));
        }

       


        



    }
}
