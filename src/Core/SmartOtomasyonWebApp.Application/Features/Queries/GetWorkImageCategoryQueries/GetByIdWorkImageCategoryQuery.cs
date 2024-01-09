using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.WorkImage;
using SmartOtomasyonWebApp.Application.Dto.WorkImageCategoryDto;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetWorkImageCategoryQueries
{
    public class GetByIdWorkImageCategoryQuery : IRequest<SuccessServiceResponse<WorkImageCategoryView>>
    {
        public Guid Id { get; set; }
        public class GetByIdWorkImageCategoryQueryHandler : IRequestHandler<GetByIdWorkImageCategoryQuery, SuccessServiceResponse<WorkImageCategoryView>>
        {
            IWorkImageCategoryRepository _workImageCategoryRepository;
            private readonly IMapper _mapper;
            public GetByIdWorkImageCategoryQueryHandler(IWorkImageCategoryRepository workImageCategoryRepository, IMapper mapper)
            {
                _workImageCategoryRepository = workImageCategoryRepository;
                _mapper = mapper;
            }

            public async Task<SuccessServiceResponse<WorkImageCategoryView>> Handle(GetByIdWorkImageCategoryQuery request, CancellationToken cancellationToken)
            {
                var category = await _workImageCategoryRepository.GetByIdAsync(request.Id);
                var viewModel = _mapper.Map<WorkImageCategoryView>(category);
                return new SuccessServiceResponse<WorkImageCategoryView>(viewModel);
            }
        }
    }
}
