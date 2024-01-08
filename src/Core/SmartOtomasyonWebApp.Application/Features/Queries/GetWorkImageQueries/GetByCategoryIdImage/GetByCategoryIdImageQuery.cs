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

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetWorkImageQueries.GetByCategoryIdImage
{
    public class GetByCategoryIdImageQuery : IRequest<ServiceResponse<List<WorkImageView>>>
    {
        public Guid categoryId { get; set; }
        public class GetByIdCategoryIdImageQueryHandler : IRequestHandler<GetByCategoryIdImageQuery, ServiceResponse<List<WorkImageView>>>
        {
            IWorkImagesRepository _workImagesRepository;
            private readonly IMapper _mapper;
            public GetByIdCategoryIdImageQueryHandler(IWorkImagesRepository workImagesRepository, IMapper mapper)
            {
                _workImagesRepository = workImagesRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<List<WorkImageView>>> Handle(GetByCategoryIdImageQuery request, CancellationToken cancellationToken)
            {
                var images = await _workImagesRepository.GetByCategoryId(request.categoryId);
                var viewModel = _mapper.Map<List<WorkImageView>>(images);
                return new ServiceResponse<List<WorkImageView>>(viewModel);
            }
        }
    }
}
