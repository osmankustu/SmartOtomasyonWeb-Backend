using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Commands.CreateCommands.CreateHome
{
    public class CreateHomeCommand : IRequest<IDataResponse<Guid>>
    {
        public String Name { get; set; }
        public Guid PageId { get; set; }

        public class CreateHomeCommandHandler : IRequestHandler<CreateHomeCommand, IDataResponse<Guid>>
        {
            IHomeRepository _homeRepostory;
            private readonly IMapper _mapper;
            public CreateHomeCommandHandler(IHomeRepository homeRepostory, IMapper mapper)
            {
                _homeRepostory = homeRepostory;
                _mapper = mapper;
            }

            public async Task<IDataResponse<Guid>> Handle(CreateHomeCommand request, CancellationToken cancellationToken)
            {
                var home = _mapper.Map<Home>(request);
                await _homeRepostory.AddAsync(home);
                return new SuccessServiceResponse<Guid>(home.Id);
            }
        }
    }
}
