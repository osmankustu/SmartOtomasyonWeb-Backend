using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Constants;
using SmartOtomasyonWebApp.Application.Dto.WorkImage;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetWorkImageQueries
{
    public class GetAllWorkImageQuery : IRequest<SuccessServiceResponse<List<WorkImageView>>>
    {
        public class GetAllWorkImageQueryHandler : IRequestHandler<GetAllWorkImageQuery, SuccessServiceResponse<List<WorkImageView>>>
        {
            IWorkImagesRepository _workImagesRepository;
            private readonly IMapper _mapper;
            public GetAllWorkImageQueryHandler(IWorkImagesRepository workImagesRepository, IMapper mapper)
            {
                _workImagesRepository = workImagesRepository;
                _mapper = mapper;
            }

            public async Task<SuccessServiceResponse<List<WorkImageView>>> Handle(GetAllWorkImageQuery request, CancellationToken cancellationToken)
            {
                var list = await _workImagesRepository.JoinedGetAllAsync();
                var viewModel = _mapper.Map<List<WorkImageView>>(list);
                return new SuccessServiceResponse<List<WorkImageView>>(viewModel, Messages.ImageListed);
            }
        }

    }
}
