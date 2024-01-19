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

namespace SmartOtomasyonWebApp.Application.Features.Commands.WorkImageCommands
{
    public class UpdateWorkImageCommand : IRequest<SuccessServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; }
        public Guid ImageCategoryId { get; set; }
        public System.Nullable<Guid> HomeId { get; set; }

        public class UpdateWorkImageCommandHandler : IRequestHandler<UpdateWorkImageCommand, SuccessServiceResponse<Guid>>
        {
            IWorkImagesRepository _workImagesRepository;
            private readonly IMapper _mapper;
            public UpdateWorkImageCommandHandler(IWorkImagesRepository workImagesRepository, IMapper mapper)
            {
                _workImagesRepository = workImagesRepository;
                _mapper = mapper;
            }

            public async Task<SuccessServiceResponse<Guid>> Handle(UpdateWorkImageCommand request, CancellationToken cancellationToken)
            {
                var image = _mapper.Map<WorkImages>(request);
                await _workImagesRepository.UpdateAsync(image);
                return new SuccessServiceResponse<Guid>(image.Id, Messages.ImageUpdated);
            }
        }
    }
}
