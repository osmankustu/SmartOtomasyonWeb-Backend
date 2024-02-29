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
    public class GetByCategoryIdPublicImageQuery : IRequest<PagginatedDataResponse<List<PublicImageView>>>
    {
        public Guid Id { get; set; }
        public int PageIndex { get; set; }

        public int PageSize { get; set; }


        public class GetByCategoryIdImageQueryHandler : IRequestHandler<GetByCategoryIdPublicImageQuery,PagginatedDataResponse<List<PublicImageView>>>
        {
            IWorkImagesRepository _repository;
            private readonly IMapper _mapper;
            public GetByCategoryIdImageQueryHandler(IWorkImagesRepository workImagesRepository,IMapper mapper)
            {
                _repository = workImagesRepository;
                _mapper = mapper;
            }

            public async Task<PagginatedDataResponse<List<PublicImageView>>> Handle(GetByCategoryIdPublicImageQuery request, CancellationToken cancellationToken)
            {
                var images = await _repository.GetByCategoryIdAsync(request.Id);
                var viewModel = _mapper.Map<List<PublicImageView>>(images);

                var totalCount = viewModel.Count;

                var itemsOnPaged = viewModel.OrderBy(i=>i.CreatedDate)
                    .Skip(request.PageSize * request.PageIndex)
                    .Take(request.PageSize)
                    .ToList();

                var pageCount = (totalCount / request.PageSize) + 1;

                return new PagginatedDataResponse<List<PublicImageView>>(itemsOnPaged,request.PageIndex,
                    request.PageSize,totalCount,pageCount);
            }
        }
    }
}
