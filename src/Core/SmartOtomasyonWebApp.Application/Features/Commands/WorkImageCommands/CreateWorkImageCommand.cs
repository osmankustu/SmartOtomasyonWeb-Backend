using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Constants;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Commands.CreateWorkImage
{
    public class CreateWorkImageCommand : IRequest<SuccessServiceResponse<Guid>>
    {
        public String Name { get; set; }
        public String Uri { get; set; }
        public Guid ImageCategoryId { get; set; }
        public System.Nullable<Guid> HomeId { get; set; }

        public class CreateWorkImageCommandHandler : IRequestHandler<CreateWorkImageCommand, SuccessServiceResponse<Guid>>
        {
            IWorkImagesRepository _workImagesRepository;
            private readonly IMapper _mapper;
            public CreateWorkImageCommandHandler(IWorkImagesRepository workImagesRepository, IMapper mapper)
            {
                _workImagesRepository = workImagesRepository;
                _mapper = mapper;
            }

            public async Task<SuccessServiceResponse<Guid>> Handle(CreateWorkImageCommand request, CancellationToken cancellationToken)
            {
                var workImage = _mapper.Map<WorkImages>(request);
                await _workImagesRepository.AddAsync(workImage);
                return new SuccessServiceResponse<Guid>(workImage.Id, Messages.ImageAdded);
            }
        }

    }
}
