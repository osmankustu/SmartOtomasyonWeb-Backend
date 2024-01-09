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

namespace SmartOtomasyonWebApp.Application.Features.Commands.EndContentCommands
{
    public class DeleteEndContentCommand : IRequest<IDataResponse<Guid>>
    {
        public Guid Id { get; set; }

        public class DeleteEndContentCommandHandler : IRequestHandler<DeleteEndContentCommand, IDataResponse<Guid>>
        {
            IEndContentRepository _endContentRepository;
            private readonly IMapper _mapper;
            public DeleteEndContentCommandHandler(IEndContentRepository endContentRepository, IMapper mapper)
            {
                _endContentRepository = endContentRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<Guid>> Handle(DeleteEndContentCommand request, CancellationToken cancellationToken)
            {
                var content = _mapper.Map<EndContent>(request);
                await _endContentRepository.DeleteAsync(content);
                return new SuccessServiceResponse<Guid>(content.Id);
            }
        }
    }
}
