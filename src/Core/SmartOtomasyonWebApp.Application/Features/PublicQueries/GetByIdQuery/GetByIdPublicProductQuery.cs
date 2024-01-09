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
    public class GetByIdPublicProductQuery : IRequest<IDataResponse<PublicGetByIdProductView>>
    {
        public Guid Id { get; set; }
        public class GetByIdPublicProductQueryHandler : IRequestHandler<GetByIdPublicProductQuery,IDataResponse<PublicGetByIdProductView>>
        {
            IProductRepository _productRepository;
            private readonly IMapper _mapper;
            public GetByIdPublicProductQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<PublicGetByIdProductView>> Handle(GetByIdPublicProductQuery request, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetByIdPublicAsync(request.Id);
                var viewModel = _mapper.Map<PublicGetByIdProductView>(product);
                return new SuccessServiceResponse<PublicGetByIdProductView>(viewModel);
            }
        }
    }
}
