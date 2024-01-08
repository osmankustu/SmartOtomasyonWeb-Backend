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

namespace SmartOtomasyonWebApp.Application.Features.Commands.UpdateCommands.UpdateFooter
{
    public class UpdateFooterCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Adress { get; set; }
        public String Mail { get; set; }

        public class UpdateFooterCommandHandler : IRequestHandler<UpdateFooterCommand , ServiceResponse<Guid>>
        {
            IFooterRepository _footerRepository;
            private readonly IMapper _mapper;
            public UpdateFooterCommandHandler(IFooterRepository footerRepository,IMapper mapper)
            {
                _mapper = mapper;
                _footerRepository = footerRepository;
            }

            public async Task<ServiceResponse<Guid>> Handle(UpdateFooterCommand request, CancellationToken cancellationToken)
            {
                var footer = _mapper.Map<Footer>(request);
                await _footerRepository.UpdateAsync(footer);
                return new ServiceResponse<Guid>(footer.Id,Messages.FooterUpdaded);
            }
        }
    }
}
