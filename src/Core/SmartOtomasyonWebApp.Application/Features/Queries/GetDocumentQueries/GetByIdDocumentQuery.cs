using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.DocumentDto;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetDocumentQueries
{
    public class GetByIdDocumentQuery : IRequest<IDataResponse<DocumentView>>
    {
        public Guid Id { get; set; }
        public class GetByIdDocumentQueryHandler : IRequestHandler<GetByIdDocumentQuery, IDataResponse<DocumentView>>
        {
            IDocumentRepository _documentRepository;
            private readonly IMapper _mappper;
            public GetByIdDocumentQueryHandler(IDocumentRepository documentRepository, IMapper mappper)
            {
                _documentRepository = documentRepository;
                _mappper = mappper;
            }

            public async Task<IDataResponse<DocumentView>> Handle(GetByIdDocumentQuery request, CancellationToken cancellationToken)
            {
                var documents = await _documentRepository.GetByIdAsync(request.Id);
                var viewModel = _mappper.Map<DocumentView>(documents);
                return new SuccessServiceResponse<DocumentView>(viewModel);
            }
        }
    }
}
