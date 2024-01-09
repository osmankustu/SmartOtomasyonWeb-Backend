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
    public class GetAllPublicProductQuery : IRequest<IDataResponse<List<PublicProductView>>>
    {
        public class GetAllProductQueryHandler : IRequestHandler<GetAllPublicProductQuery, IDataResponse<List<PublicProductView>>>
        {
            IProductRepository _productRepository;
            private readonly IMapper _mapper;
            public GetAllProductQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<List<PublicProductView>>> Handle(GetAllPublicProductQuery request, CancellationToken cancellationToken)
            {
                var products = await _productRepository.GetAllPublicAsync();
                var viewModel = _mapper.Map<List<PublicProductView>>(products);
                return new SuccessServiceResponse<List<PublicProductView>>(viewModel);
            }
        }
    }
}
