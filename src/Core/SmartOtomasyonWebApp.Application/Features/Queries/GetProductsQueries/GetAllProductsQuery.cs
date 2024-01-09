using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.Product;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetProductsQueries
{
    public class GetAllProductsQuery : IRequest<SuccessServiceResponse<List<ProductViewDto>>>
    {

        public class GetAllProductQueryHandler : IRequestHandler<GetAllProductsQuery, SuccessServiceResponse<List<ProductViewDto>>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;
            public GetAllProductQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }
            public async Task<SuccessServiceResponse<List<ProductViewDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await _productRepository.GetAllAsync();
                var viewModel = _mapper.Map<List<ProductViewDto>>(products);
                return new SuccessServiceResponse<List<ProductViewDto>>(viewModel);
            }
        }
    }
}
