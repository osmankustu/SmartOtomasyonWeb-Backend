using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.WorkImage;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetWorkImageQueries.GetByIdWorkImage
{
    public class GetByIdWorkImageQuery : IRequest<ServiceResponse<WorkImageView>>
    {
        public Guid Id { get; set; }

        public class GetByIdWorkImageCommandHandler : IRequestHandler<GetByIdWorkImageQuery, ServiceResponse<WorkImageView>>
        {
            IWorkImagesRepository _workImagesRepository;
            private readonly IMapper _mapper;
            public GetByIdWorkImageCommandHandler(IWorkImagesRepository workImagesRepository, IMapper mapper)
            {
                _workImagesRepository = workImagesRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<WorkImageView>> Handle(GetByIdWorkImageQuery request, CancellationToken cancellationToken)
            {
                var image = await _workImagesRepository.GetByIdAsync(request.Id);
                var viewModel = _mapper.Map<WorkImageView>(image);
                return new ServiceResponse<WorkImageView>(viewModel);
            }
        }
    }
}
