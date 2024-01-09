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

namespace SmartOtomasyonWebApp.Application.Features.Commands.MetaCommands
{
    public class DeleteMetaCommand : IRequest<SuccessServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
        public class CreateMetaCommandHandler : IRequestHandler<DeleteMetaCommand, SuccessServiceResponse<Guid>>
        {
            IMetaRepository _metaRepository;
            private readonly IMapper _mapper;
            public CreateMetaCommandHandler(IMetaRepository metaRepository, IMapper mapper)
            {
                _metaRepository = metaRepository;
                _mapper = mapper;
            }

            public async Task<SuccessServiceResponse<Guid>> Handle(DeleteMetaCommand request, CancellationToken cancellationToken)
            {
                var meta = _mapper.Map<Meta>(request);
                await _metaRepository.DeleteAsync(meta);
                return new SuccessServiceResponse<Guid>(meta.Id);
            }
        }
    }
}
