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

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetWorkImageQueries.GetAllWorkImage
{
    public class GetAllWorkImageQueryHandler : IRequestHandler<GetAllWorkImageQuery,ServiceResponse<List<WorkImageView>>>
    {
        IWorkImagesRepository _workImagesRepository;
        private readonly IMapper _mapper;
        public GetAllWorkImageQueryHandler(IWorkImagesRepository workImagesRepository, IMapper mapper)
        {
            _workImagesRepository = workImagesRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<WorkImageView>>> Handle(GetAllWorkImageQuery request, CancellationToken cancellationToken)
        {
            var list = await _workImagesRepository.JoinedGetAllAsync();
            var viewModel = _mapper.Map<List<WorkImageView>>(list);
            return new ServiceResponse<List<WorkImageView>>(viewModel,Messages.ImageListed);
        }
    }
}
