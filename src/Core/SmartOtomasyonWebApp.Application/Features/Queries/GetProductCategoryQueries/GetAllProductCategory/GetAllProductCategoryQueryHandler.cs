using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.ProductCategory;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetProductCategoryQueries.GetAllProductCategory
{
    public class GetAllProductCategoryQueryHandler : IRequestHandler<GetAllProductCategoryQuery,ServiceResponse<List<ProductCategoryView>>>
    {
        IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;
        public GetAllProductCategoryQueryHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<ProductCategoryView>>> Handle(GetAllProductCategoryQuery request, CancellationToken cancellationToken)
        {
            var list = await _productCategoryRepository.GetAllAsync();
            var viewModel = _mapper.Map<List<ProductCategoryView>>(list);
            return new ServiceResponse<List<ProductCategoryView>>(viewModel);
        }
    }
}
