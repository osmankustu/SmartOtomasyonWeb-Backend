﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateReferance;
using SmartOtomasyonWebApp.Application.Features.Commands.DeleteCommands.DeleteReferance;
using SmartOtomasyonWebApp.Application.Features.Commands.UpdateCommands.UpdateReferance;
using SmartOtomasyonWebApp.Application.Features.Queries.PublicQueries;
using SmartOtomasyonWebApp.Application.Features.Queries.ReferanceQueries.GetAllReferance;
using SmartOtomasyonWebApp.Application.Features.Queries.ReferanceQueries.GetByIdReferance;

namespace SmartOtomasyonWebApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferanceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReferanceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllReferanceQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetByIdReferanceQuery { Id = id };
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateReferanceCommand command)
        {
            
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteReferanceCommand() { Id=id};
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateReferanceCommand command)
        {
            return Ok(await _mediator.Send(command));

        }

        [HttpGet("public")]
        public async Task<IActionResult> GetAllPublic()
        {
            var query = new GetAllPublicReferanceQuery();
            return Ok(await _mediator.Send(query));
        }
    }
}
