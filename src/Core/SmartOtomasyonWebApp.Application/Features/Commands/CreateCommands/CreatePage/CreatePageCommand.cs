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

namespace SmartOtomasyonWebApp.Application.Features.Commands.CreateCommands.CreatePage
{
    public class CreatePageCommand : IRequest<ServiceResponse<Guid>>
    {
        public String Name { get; set; }

        public class CreatePageCommandHandler : IRequestHandler<CreatePageCommand, ServiceResponse<Guid>> 
        {
            IPagesRepository _pagesRepository;
            private readonly IMapper _mapper;
            public CreatePageCommandHandler(IPagesRepository pagesRepository, IMapper mapper)
            {
                _pagesRepository = pagesRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreatePageCommand request, CancellationToken cancellationToken)
            {
                var pages = _mapper.Map<Page>(request);
                await _pagesRepository.AddAsync(pages);
                return new ServiceResponse<Guid>(pages.Id);
            }
        }
    }
}
