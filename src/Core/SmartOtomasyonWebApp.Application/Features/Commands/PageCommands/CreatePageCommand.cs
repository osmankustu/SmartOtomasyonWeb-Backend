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
    public class CreatePageCommand : IRequest<SuccessServiceResponse<Guid>>
    {
        public String Name { get; set; }

        public class CreatePageCommandHandler : IRequestHandler<CreatePageCommand, SuccessServiceResponse<Guid>> 
        {
            IPagesRepository _pagesRepository;
            private readonly IMapper _mapper;
            public CreatePageCommandHandler(IPagesRepository pagesRepository, IMapper mapper)
            {
                _pagesRepository = pagesRepository;
                _mapper = mapper;
            }

            public async Task<SuccessServiceResponse<Guid>> Handle(CreatePageCommand request, CancellationToken cancellationToken)
            {
                var pages = _mapper.Map<Page>(request);
                await _pagesRepository.AddAsync(pages);
                return new SuccessServiceResponse<Guid>(pages.Id);
            }
        }
    }
}
