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

namespace SmartOtomasyonWebApp.Application.Features.Commands.UpdateCommands.UpdateWorkImage
{
    public class UpdateWorkImageCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Uri { get; set; }
        public Guid ImageCategoryId { get; set; }

        public class UpdateWorkImageCommandHandler : IRequestHandler<UpdateWorkImageCommand, ServiceResponse<Guid>>
        {
            IWorkImagesRepository _workImagesRepository;
            private readonly IMapper _mapper;
            public UpdateWorkImageCommandHandler(IWorkImagesRepository workImagesRepository, IMapper mapper)
            {
                _workImagesRepository = workImagesRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(UpdateWorkImageCommand request, CancellationToken cancellationToken)
            {
                var image = _mapper.Map<WorkImages>(request);
                await _workImagesRepository.UpdateAsync(image);
                return new ServiceResponse<Guid>(image.Id,Messages.ImageUpdated);
            }
        }
    }
}
