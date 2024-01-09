using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Commands.HomeCommands
{
    public class UpdateHomeCommand : IRequest<IDataResponse<Guid>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid PageId { get; set; }

        public class CreateHomeCommandHandler : IRequestHandler<UpdateHomeCommand, IDataResponse<Guid>>
        {
            IHomeRepository _homeRepostory;
            private readonly IMapper _mapper;
            public CreateHomeCommandHandler(IHomeRepository homeRepostory, IMapper mapper)
            {
                _homeRepostory = homeRepostory;
                _mapper = mapper;
            }

            public async Task<IDataResponse<Guid>> Handle(UpdateHomeCommand request, CancellationToken cancellationToken)
            {
                var home = _mapper.Map<Home>(request);
                await _homeRepostory.UpdateAsync(home);
                return new SuccessServiceResponse<Guid>(home.Id);
            }
        }
    }
}
