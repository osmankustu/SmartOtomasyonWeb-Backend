using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.DocumentDto;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.PublicQueries.GetByIdQuery
{
    public class GetByCategoryIdDocumentQuery : IRequest<IDataResponse<List<DocumentView>>>
    {
        public Guid Id { get; set; }
        public class GetByCategoryIdDocumentQueryHandler : IRequestHandler<GetByCategoryIdDocumentQuery,IDataResponse<List<DocumentView>>>
        {
            IDocumentRepository _documentRepository;
            private readonly IMapper _mapper;
            public GetByCategoryIdDocumentQueryHandler(IDocumentRepository documentRepository, IMapper mapper)
            {
                _documentRepository = documentRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<List<DocumentView>>> Handle(GetByCategoryIdDocumentQuery request, CancellationToken cancellationToken)
            {
                var documents = await _documentRepository.getByCategoryIdAsync(request.Id);
                var viewModel = _mapper.Map<List<DocumentView>>(documents);
                return new SuccessServiceResponse<List<DocumentView>>(viewModel);
            }
        }
    }
}
