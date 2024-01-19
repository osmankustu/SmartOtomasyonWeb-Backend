using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Constants;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartOtomasyonWebApp.Domain.Entities;

namespace SmartOtomasyonWebApp.Application.Features.Commands.DocumentCommands
{
    public class DeleteDocumentCommand : IRequest<IDataResponse<Guid>>
    {
        public Guid Id { get; set; }

        public class DeleteDocumentCommandHandler : IRequestHandler<DeleteDocumentCommand, IDataResponse<Guid>>
        {
            IDocumentRepository _documentRepository;
            private readonly IMapper _mapper;
            public DeleteDocumentCommandHandler(IDocumentRepository documentRepository, IMapper mapper)
            {
                _documentRepository = documentRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<Guid>> Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
            {
                var document = _mapper.Map<Document>(request);
                await _documentRepository.DeleteAsync(document);
                return new SuccessServiceResponse<Guid>(document.Id, Messages.DocumentDeleted);
            }
        }
    }
}
