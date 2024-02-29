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

namespace SmartOtomasyonWebApp.Application.Features.Queries.PublicQueries.GetByIdQuery
{
    public class GetByCategoryIdPublicProductQuery : IRequest<PagginatedDataResponse<List<PublicProductView>>>
    {
        public Guid Id { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public class GetByCategoryIdPublicProductQueryHandler : IRequestHandler<GetByCategoryIdPublicProductQuery,PagginatedDataResponse<List<PublicProductView>>>
        {
            IProductRepository _productRepository;
            private readonly IMapper _mapper;
            public GetByCategoryIdPublicProductQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<PagginatedDataResponse<List<PublicProductView>>> Handle(GetByCategoryIdPublicProductQuery request, CancellationToken cancellationToken)
            {
                var products = await _productRepository.GetByCategoryIdAsync(request.Id);
                var viewModel = _mapper.Map<List<PublicProductView>>(products);

                var totalCount = viewModel.Count;

                var itemsOnPage = viewModel.OrderBy(i => i.Name)
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
