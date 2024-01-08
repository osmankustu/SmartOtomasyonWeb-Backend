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

namespace SmartOtomasyonWebApp.Application.Features.Commands.UpdateCommands.UpdatePage
{
    public class UpdatePageCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
        public String Name { get; set; }

        public class UpdatePageCommandHandler : IRequestHandler<UpdatePageCommand, ServiceResponse<Guid>>
        {
            IPagesRepository _pagesRepository;
            private readonly IMapper _mapper;
            public UpdatePageCommandHandler(IPagesRepository pagesRepository, IMapper mapper)
            {
                _pagesRepository = pagesRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(UpdatePageCommand request, CancellationToken cancellationToken)
            {
                var pages = _mapper.Map<Page>(request);
                await _pagesRepository.UpdateAsync(pages);
                return new ServiceResponse<Guid>(pages.Id);
            }
        }
    }
}
