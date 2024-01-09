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

namespace SmartOtomasyonWebApp.Application.Features.Commands.EndContentCommands
{
    public class CreateEndContentCommand :IRequest<IDataResponse<Guid>>
    {
        public String SiteName { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public Guid HomeId { get; set; }

        public class CreateEndContentCommandHandler : IRequestHandler<CreateEndContentCommand, IDataResponse<Guid>>
        {
            IEndContentRepository _endContentRepository;
            private readonly IMapper _mapper;
            public CreateEndContentCommandHandler(IEndContentRepository endContentRepository, IMapper mapper)
            {
                _endContentRepository = endContentRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<Guid>> Handle(CreateEndContentCommand request, CancellationToken cancellationToken)
            {
                var content = _mapper.Map<EndContent>(request);
                await _endContentRepository.AddAsync(content);
                return new SuccessServiceResponse<Guid>(content.Id);
            }
        }
    }
}
