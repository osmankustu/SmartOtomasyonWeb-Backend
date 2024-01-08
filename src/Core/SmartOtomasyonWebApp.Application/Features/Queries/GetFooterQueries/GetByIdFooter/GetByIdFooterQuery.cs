using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.Footer;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetFooterQueries.GetByIdFooter
{
    public class GetByIdFooterQuery : IRequest<ServiceResponse<FooterView>>
    {
        public Guid Id { get; set; }

        public class GetByIdFooterQueryHandler : IRequestHandler<GetByIdFooterQuery,ServiceResponse<FooterView>>
        {
            IFooterRepository _footerRepository;
            private readonly IMapper _mapper;
            public GetByIdFooterQueryHandler(IFooterRepository footerRepository, IMapper mapper)
            {
                _footerRepository = footerRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<FooterView>> Handle(GetByIdFooterQuery request, CancellationToken cancellationToken)
            {
                var footer = await _footerRepository.GetByIdAsync(request.Id);
                var viewModel = _mapper.Map<FooterView>(footer);
                return new ServiceResponse<FooterView>(viewModel);
            }
        }
    }
}
