using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.PublicDTOs;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.PublicQueries
{
    public class GetAllPublicImageCategoryQuery : IRequest<IDataResponse<List<PublicImageCategoryView>>>
    {
        public class GetAllPublicImageCategoryQueryHandler : IRequestHandler<GetAllPublicImageCategoryQuery,IDataResponse<List<PublicImageCategoryView>>>
        {
            IWorkImageCategoryRepository _repository;
            private readonly IMapper _mapper;
            public GetAllPublicImageCategoryQueryHandler(IWorkImageCategoryRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<List<PublicImageCategoryView>>> Handle(GetAllPublicImageCategoryQuery request, CancellationToken cancellationToken)
            {
                var category = await _repository.GetAllPublicAsync();
                var viewModel = _mapper.Map<List<PublicImageCategoryView>>(category);
                return new SuccessServiceResponse<List<PublicImageCategoryView>>(viewModel);
            }
        }
    }
}
