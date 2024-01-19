using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.DocumentCategoryDto;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetDocumentCategoryQueries
{
    public class GetAllDocumentCategoryQuery : IRequest<IDataResponse<List<DocumentCategoryView>>>
    {
        public class GetAllDocumentCategoryQueryHandler : IRequestHandler<GetAllDocumentCategoryQuery,IDataResponse<List<DocumentCategoryView>>>
        {
            IDocumentCategoryRepository _documentCategory;
            private readonly IMapper _mapper;
            public GetAllDocumentCategoryQueryHandler(IDocumentCategoryRepository documentCategoryRepository , IMapper mapper)
            {
                _documentCategory = documentCategoryRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<List<DocumentCategoryView>>> Handle(GetAllDocumentCategoryQuery request, CancellationToken cancellationToken)
            {
                var categories = await _documentCategory.GetAllAsync();
                var viewModel = _mapper.Map<List<DocumentCategoryView>>(categories);
                return new SuccessServiceResponse<List<DocumentCategoryView>>(viewModel);
            }
        }
    }
}
