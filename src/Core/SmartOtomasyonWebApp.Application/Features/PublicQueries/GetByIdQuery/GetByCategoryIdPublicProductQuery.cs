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

namespace SmartOtomasyonWebApp.Application.Features.Queries.PublicQueries.GetByIdQuery
{
    public class GetByCategoryIdPublicProductQuery : IRequest<IDataResponse<List<PublicProductView>>>
    {
        public Guid Id { get; set; }
        public class GetByCategoryIdPublicProductQueryHandler : IRequestHandler<GetByCategoryIdPublicProductQuery,IDataResponse<List<PublicProductView>>>
        {
            IProductRepository _productRepository;
            private readonly IMapper _mapper;
            public GetByCategoryIdPublicProductQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<List<PublicProductView>>> Handle(GetByCategoryIdPublicProductQuery request, CancellationToken cancellationToken)
            {
                var products = await _productRepository.GetByCategoryIdAsync(request.Id);
                var viewModel = _mapper.Map<List<PublicProductView>>(products);
                return new SuccessServiceResponse<List<PublicProductView>>(viewModel);
            }
        }
    }
}
