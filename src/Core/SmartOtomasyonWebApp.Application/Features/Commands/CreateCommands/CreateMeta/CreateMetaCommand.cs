using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Commands.CreateCommands.CreateMeta
{
    public class CreateMetaCommand : IRequest<ServiceResponse<Guid>>
    {
        public String Name { get; set; }
        public String Content { get; set; }
        public Guid PageId { get; set; }

        public class CreateMetaCommandHandler : IRequestHandler<CreateMetaCommand,ServiceResponse<Guid>>
        {
            IMetaRepository _metaRepository;
            private readonly IMapper _mapper;
            public CreateMetaCommandHandler(IMetaRepository metaRepository, IMapper mapper)
            {
                _metaRepository = metaRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreateMetaCommand request, CancellationToken cancellationToken)
            {
                var meta = _mapper.Map<Meta>(request);
                await _metaRepository.AddAsync(meta);
                return new ServiceResponse<Guid>(meta.Id);
            }
        }
    }
}
