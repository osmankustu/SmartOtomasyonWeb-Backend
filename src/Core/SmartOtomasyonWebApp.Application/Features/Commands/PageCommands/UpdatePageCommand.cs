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
    public class UpdatePageCommand : IRequest<SuccessServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public class UpdatePageCommandHandler : IRequestHandler<UpdatePageCommand, SuccessServiceResponse<Guid>>
        {
            IPagesRepository _pagesRepository;
            private readonly IMapper _mapper;
            public UpdatePageCommandHandler(IPagesRepository pagesRepository, IMapper mapper)
            {
                _pagesRepository = pagesRepository;
                _mapper = mapper;
            }

            public async Task<SuccessServiceResponse<Guid>> Handle(UpdatePageCommand request, CancellationToken cancellationToken)
            {
                var pages = _mapper.Map<Page>(request);
                await _pagesRepository.UpdateAsync(pages);
                return new SuccessServiceResponse<Guid>(pages.Id);
            }
        }
    }
}
