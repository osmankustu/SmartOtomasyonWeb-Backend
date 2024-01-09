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
    public class DeleteFooterCommand : IRequest<SuccessServiceResponse<Guid>>
    {
        public Guid Id { get; set; }

        public class DeleteFooterCommandHandler : IRequestHandler<DeleteFooterCommand, SuccessServiceResponse<Guid>>
        {
            IFooterRepository _footerRepository;
            private readonly IMapper _mapper;
            public DeleteFooterCommandHandler(IFooterRepository footerRepository, IMapper mapper)
            {
                _footerRepository = footerRepository;
                _mapper = mapper;
            }

            public async Task<SuccessServiceResponse<Guid>> Handle(DeleteFooterCommand request, CancellationToken cancellationToken)
            {
                var footer = _mapper.Map<Footer>(request);
                await _footerRepository.DeleteAsync(footer);
                return new SuccessServiceResponse<Guid>(footer.Id, Messages.FooterDeleted);

            }
        }
    }
}
