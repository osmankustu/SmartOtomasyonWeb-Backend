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

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetWorkImageQueries
{
    public class GetByCategoryIdImageQuery : IRequest<SuccessServiceResponse<List<WorkImageView>>>
    {
        public Guid categoryId { get; set; }
        public class GetByIdCategoryIdImageQueryHandler : IRequestHandler<GetByCategoryIdImageQuery, SuccessServiceResponse<List<WorkImageView>>>
        {
            IWorkImagesRepository _workImagesRepository;
            private readonly IMapper _mapper;
            public GetByIdCategoryIdImageQueryHandler(IWorkImagesRepository workImagesRepository, IMapper mapper)
            {
                _workImagesRepository = workImagesRepository;
                _mapper = mapper;
            }

            public async Task<SuccessServiceResponse<List<WorkImageView>>> Handle(GetByCategoryIdImageQuery request, CancellationToken cancellationToken)
            {
                var images = await _workImagesRepository.GetByCategoryIdAsync(request.categoryId);
                var viewModel = _mapper.Map<List<WorkImageView>>(images);
                return new SuccessServiceResponse<List<WorkImageView>>(viewModel);
            }
        }
    }
}
