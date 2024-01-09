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
    public class DeleteWorkImagesCommand : IRequest<SuccessServiceResponse<Guid>>
    {
        public Guid Id { get; set; }

        public class DeleteWorkImagesCommandHandler : IRequestHandler<DeleteWorkImagesCommand, SuccessServiceResponse<Guid>>
        {
            IWorkImagesRepository _workImagesRepository;
            private readonly IMapper _mapper;
            public DeleteWorkImagesCommandHandler(IWorkImagesRepository workImagesRepository, IMapper mapper)
            {
                _workImagesRepository = workImagesRepository;
                _mapper = mapper;
            }

            public async Task<SuccessServiceResponse<Guid>> Handle(DeleteWorkImagesCommand request, CancellationToken cancellationToken)
            {
                var image = _mapper.Map<WorkImages>(request);
                await _workImagesRepository.DeleteAsync(image);
                return new SuccessServiceResponse<Guid>(image.Id, Messages.ImageDeleted);
            }
        }
    }
}
