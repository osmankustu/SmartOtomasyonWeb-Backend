using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.PublicDTOs;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using SmartOtomasyonWebApp.Application.Wrappers.Pagging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.PublicQueries
{
    public class GetAllPublicProductQuery : IRequest<PagginatedDataResponse<List<PublicProductView>>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        
        public class GetAllProductQueryHandler : IRequestHandler<GetAllPublicProductQuery, PagginatedDataResponse<List<PublicProductView>>>
        {
            
            IProductRepository _productRepository;
            private readonly IMapper _mapper;
            public GetAllProductQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<PagginatedDataResponse<List<PublicProductView>>> Handle(GetAllPublicProductQuery request, CancellationToken cancellationToken)
            {
                var products = await _productRepository.GetAllPublicAsync();
                var viewModel = _mapper.Map<List<PublicProductView>>(products);

                var totalCount = viewModel.Count;

                var itemsOnPage = viewModel.OrderBy(i=>i.CreateAt)
                    .Skip(request.PageIndex * request.PageSize)
                    .Take(request.PageSize)
                    .ToList();

                var pageCount = (totalCount / request.PageSize) + 1;

                return new PagginatedDataResponse<List<PublicProductView>>(itemsOnPage,request.PageIndex,
                    request.PageSize,totalCount,pageCount);
            }
        }
    }
}
