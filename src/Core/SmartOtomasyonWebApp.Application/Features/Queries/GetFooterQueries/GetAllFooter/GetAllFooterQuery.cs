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

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetFooterQueries.GetAllFooter
{
    public class GetAllFooterQuery : IRequest<ServiceResponse<List<FooterView>>>
    {
        public class GetAllFooterQueryHandler : IRequestHandler<GetAllFooterQuery, ServiceResponse<List<FooterView>>>
        {
            IFooterRepository _footerRepository;
            private readonly IMapper _mapper;
            public GetAllFooterQueryHandler(IFooterRepository footerRepository, IMapper mapper)
            {
                _footerRepository = footerRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<List<FooterView>>> Handle(GetAllFooterQuery request, CancellationToken cancellationToken)
            {
                var footers = await _footerRepository.JoinedGetAllAsync();
                var viewModel = _mapper.Map<List<FooterView>>(footers);
                return new ServiceResponse<List<FooterView>>(viewModel);
            }
        }
    }
}
