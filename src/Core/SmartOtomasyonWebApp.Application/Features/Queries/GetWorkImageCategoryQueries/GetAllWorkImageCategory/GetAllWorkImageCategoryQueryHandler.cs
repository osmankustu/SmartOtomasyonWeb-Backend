using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.WorkImageCategoryDto;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetWorkImageCategoryQueries.GetAllWorkImageCategory
{
    public class GetAllWorkImageCategoryQueryHandler : IRequestHandler<GetAllWorkImageCategoryQuery,ServiceResponse<List<WorkImageCategoryView>>>
    {
        IWorkImageCategoryRepository _workImageCategoryRepository;
        private readonly IMapper _mapper;
        public GetAllWorkImageCategoryQueryHandler(IWorkImageCategoryRepository workImageCategoryRepository, IMapper mapper)
        {
            _workImageCategoryRepository = workImageCategoryRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<WorkImageCategoryView>>> Handle(GetAllWorkImageCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _workImageCategoryRepository.GetAllAsync();
            var viewModel= _mapper.Map<List<WorkImageCategoryView>>(categories);
            return new ServiceResponse<List<WorkImageCategoryView>>(viewModel);
        }
    }
}
