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
    public class UpdateDocumentCommand : IRequest<IDataResponse<Guid>>
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Uri { get; set; }
        public Guid DocumentCategoryId { get; set; }

        public class UpdateDocumentCommandHandler : IRequestHandler<UpdateDocumentCommand, IDataResponse<Guid>>
        {
            IDocumentRepository _documentRepository;
            private readonly IMapper _mapper;
            public UpdateDocumentCommandHandler(IDocumentRepository documentRepository, IMapper mapper)
            {
                _documentRepository = documentRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<Guid>> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
            {
                var document = _mapper.Map<Document>(request);
                await _documentRepository.UpdateAsync(document);
                return new SuccessServiceResponse<Guid>(document.Id, Messages.DocumentUpdaded);
            }
        }
    }
}
