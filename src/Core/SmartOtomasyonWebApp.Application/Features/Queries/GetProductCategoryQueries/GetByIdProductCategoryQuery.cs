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

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetProductCategoryQueries
{
    public class GetByIdProductCategoryQuery : IRequest<SuccessServiceResponse<ProductCategoryView>>
    {
        public Guid Id { get; set; }
        public class GetByIdProductCategoryQueryHnadler : IRequestHandler<GetByIdProductCategoryQuery, SuccessServiceResponse<ProductCategoryView>>
        {
            IProductCategoryRepository _productCategoryRepository;
            private readonly IMapper _mapper;
            public GetByIdProductCategoryQueryHnadler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
            {
                _productCategoryRepository = productCategoryRepository;
                _mapper = mapper;
            }

            public async Task<SuccessServiceResponse<ProductCategoryView>> Handle(GetByIdProductCategoryQuery request, CancellationToken cancellationToken)
            {
                var product = await _productCategoryRepository.GetByIdAsync(request.Id);
                var viewModel = _mapper.Map<ProductCategoryView>(product);
                return new SuccessServiceResponse<ProductCategoryView>(viewModel);
            }
        }
    }
}
