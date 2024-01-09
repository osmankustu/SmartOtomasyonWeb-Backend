using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Commands.PageCommands
{
    public class DeletePageCommand : IRequest<SuccessServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
        public class DeletePageCommandHandler : IRequestHandler<DeletePageCommand, SuccessServiceResponse<Guid>>
        {
            IPagesRepository _pagesRepository;
            private readonly IMapper _mapper;
            public DeletePageCommandHandler(IPagesRepository pagesRepository, IMapper mapper)
            {
                _pagesRepository = pagesRepository;
                _mapper = mapper;
            }

            public async Task<SuccessServiceResponse<Guid>> Handle(DeletePageCommand request, CancellationToken cancellationToken)
            {
                var page = _mapper.Map<Page>(request);
                await _pagesRepository.DeleteAsync(page);
                return new SuccessServiceResponse<Guid>(page.Id);
            }
        }
    }
}
