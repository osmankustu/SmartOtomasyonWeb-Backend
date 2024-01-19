using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Constants;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Commands.DocumentCommands
{
    public class CreateDocumentCommand : IRequest<IDataResponse<Guid>>
    {
        public String Name { get; set; }
        public String Uri { get; set; }
        public Guid DocumentCategoryId { get; set; }

        public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand,IDataResponse<Guid>>
        {
            IDocumentRepository _documentRepository;
            private readonly IMapper _mapper;
            public CreateDocumentCommandHandler(IDocumentRepository documentRepository, IMapper mapper)
            {
                _documentRepository = documentRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<Guid>> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
            {
                var document = _mapper.Map<Document>(request);
                await _documentRepository.AddAsync(document) ;
                return new SuccessServiceResponse<Guid>(document.Id,Messages.DocumentAdded);
            }
        }
    }
}
