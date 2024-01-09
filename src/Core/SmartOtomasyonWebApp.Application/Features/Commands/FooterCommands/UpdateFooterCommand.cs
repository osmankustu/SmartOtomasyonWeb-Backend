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

namespace SmartOtomasyonWebApp.Application.Features.Commands.FooterCommands
{
    public class UpdateFooterCommand : IRequest<SuccessServiceResponse<Guid>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Mail { get; set; }
        public Guid PageId { get; set; }

        public class UpdateFooterCommandHandler : IRequestHandler<UpdateFooterCommand, SuccessServiceResponse<Guid>>
        {
            IFooterRepository _footerRepository;
            private readonly IMapper _mapper;
            public UpdateFooterCommandHandler(IFooterRepository footerRepository, IMapper mapper)
            {
                _mapper = mapper;
                _footerRepository = footerRepository;
            }

            public async Task<SuccessServiceResponse<Guid>> Handle(UpdateFooterCommand request, CancellationToken cancellationToken)
            {
                var footer = _mapper.Map<Footer>(request);
                await _footerRepository.UpdateAsync(footer);
                return new SuccessServiceResponse<Guid>(footer.Id, Messages.FooterUpdaded);
            }
        }
    }
}
