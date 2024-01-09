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
    public class GetAllPublicProductCategoryQuery : IRequest<IDataResponse<List<PublicProductCategoryView>>>
    {
        public class GetAllPublicProductCategoryQueryHandler : IRequestHandler<GetAllPublicProductCategoryQuery,IDataResponse<List<PublicProductCategoryView>>>
        {
            IProductCategoryRepository _repository;
            private readonly IMapper _mapper;
            public GetAllPublicProductCategoryQueryHandler(IProductCategoryRepository productCategoryRepository,IMapper mapper)
            {
                _repository = productCategoryRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<List<PublicProductCategoryView>>> Handle(GetAllPublicProductCategoryQuery request, CancellationToken cancellationToken)
            {
                var category = await _repository.GetAllPublicAsync();
                var viewModel = _mapper.Map<List<PublicProductCategoryView>>(category);
                return new SuccessServiceResponse<List<PublicProductCategoryView>>(viewModel);
            }
        }
    }
}
