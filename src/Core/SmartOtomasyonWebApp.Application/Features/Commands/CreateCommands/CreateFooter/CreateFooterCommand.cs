using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Constants;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Commands.CreateFooter
{
    public class CreateFooterCommand : IRequest<ServiceResponse<Guid>>
    {
        public String Name { get; set; }
        public String Adress { get; set; }
        public String Mail { get; set; }

       public class CreateFooterCommandHandler : IRequestHandler<CreateFooterCommand, ServiceResponse<Guid>>
        {
            IFooterRepository _footerRepository;
            private readonly IMapper _mapper;
            public CreateFooterCommandHandler(IFooterRepository footerRepository, IMapper mapper)
            {
                _footerRepository = footerRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreateFooterCommand request, CancellationToken cancellationToken)
            {
                var footer = _mapper.Map<Footer>(request);
                await _footerRepository.AddAsync(footer);
                return new ServiceResponse<Guid>(footer.Id,Messages.FooterAdded);
            }
        }
    }
}
