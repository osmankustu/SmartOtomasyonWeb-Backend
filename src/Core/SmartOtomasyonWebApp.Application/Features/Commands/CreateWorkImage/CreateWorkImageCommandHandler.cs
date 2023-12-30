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

namespace SmartOtomasyonWebApp.Application.Features.Commands.CreateWorkImage
{
    public class CreateWorkImageCommandHandler : IRequestHandler<CreateWorkImageCommand,ServiceResponse<Guid>>
    {
        IWorkImagesRepository _workImagesRepository;
        private readonly IMapper _mapper;
        public CreateWorkImageCommandHandler(IWorkImagesRepository workImagesRepository, IMapper mapper)
        {
            _workImagesRepository = workImagesRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(CreateWorkImageCommand request, CancellationToken cancellationToken)
        {
            var workImage = _mapper.Map<WorkImages>(request);
            await _workImagesRepository.AddAsync(workImage);
            return new ServiceResponse<Guid>(workImage.Id);
        }
    }
}
