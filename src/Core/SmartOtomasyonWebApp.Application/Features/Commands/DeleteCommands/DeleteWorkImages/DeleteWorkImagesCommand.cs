using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Constants;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Commands.DeleteCommands.DeleteWorkImages
{
    public class DeleteWorkImagesCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }

        public class DeleteWorkImagesCommandHandler : IRequestHandler<DeleteWorkImagesCommand, ServiceResponse<Guid>>
        {
            IWorkImagesRepository _workImagesRepository;
            private readonly IMapper _mapper;
            public DeleteWorkImagesCommandHandler(IWorkImagesRepository workImagesRepository, IMapper mapper)
            {
                _workImagesRepository = workImagesRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(DeleteWorkImagesCommand request, CancellationToken cancellationToken)
            {
                var image = _mapper.Map<WorkImages>(request);
                await _workImagesRepository.DeleteAsync(image);
                return new ServiceResponse<Guid>(image.Id,Messages.ImageDeleted);
            }
        }
    }
}
