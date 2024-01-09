using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto;
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
    public class GetProductByIdQuery : IRequest<SuccessServiceResponse<ProductViewDto>>
    {
        public Guid Id { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, SuccessServiceResponse<ProductViewDto>>
        {
            IProductRepository _productRepository;
            private readonly IMapper _mapper;
            public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<SuccessServiceResponse<ProductViewDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetByIdAsync(request.Id);
                var dto = _mapper.Map<ProductViewDto>(product);
                return new SuccessServiceResponse<ProductViewDto>(dto);
            }
        }
    }
}
