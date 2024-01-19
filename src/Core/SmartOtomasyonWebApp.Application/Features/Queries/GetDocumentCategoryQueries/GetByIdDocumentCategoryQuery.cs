using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.DocumentCategoryDto;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetDocumentCategoryQueries
{
    public class GetByIdDocumentCategoryQuery : IRequest<IDataResponse<DocumentCategoryView>>
    {
        public Guid Id { get; set; }
        public class GetByIdDocumentCategoryQueryHandler : IRequestHandler<GetByIdDocumentCategoryQuery, IDataResponse<DocumentCategoryView>>
        {
            IDocumentCategoryRepository _documentCategory;
            private readonly IMapper _mapper;
            public GetByIdDocumentCategoryQueryHandler(IDocumentCategoryRepository documentCategoryRepository, IMapper mapper)
            {
                _documentCategory = documentCategoryRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<DocumentCategoryView>> Handle(GetByIdDocumentCategoryQuery request, CancellationToken cancellationToken)
            {
                var categories = await _documentCategory.GetByIdAsync(request.Id);
                var viewModel = _mapper.Map<DocumentCategoryView>(categories);
                return new SuccessServiceResponse<DocumentCategoryView>(viewModel);
            }
        }
    }
}
