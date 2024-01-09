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

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetFooterQueries
{
    public class GetAllFooterQuery : IRequest<SuccessServiceResponse<List<FooterView>>>
    {
        public class GetAllFooterQueryHandler : IRequestHandler<GetAllFooterQuery, SuccessServiceResponse<List<FooterView>>>
        {
            IFooterRepository _footerRepository;
            private readonly IMapper _mapper;
            public GetAllFooterQueryHandler(IFooterRepository footerRepository, IMapper mapper)
            {
                _footerRepository = footerRepository;
                _mapper = mapper;
            }

            public async Task<SuccessServiceResponse<List<FooterView>>> Handle(GetAllFooterQuery request, CancellationToken cancellationToken)
            {
                var footers = await _footerRepository.GetAllAsync();
                var viewModel = _mapper.Map<List<FooterView>>(footers);
                return new SuccessServiceResponse<List<FooterView>>(viewModel);
            }
        }
    }
}
