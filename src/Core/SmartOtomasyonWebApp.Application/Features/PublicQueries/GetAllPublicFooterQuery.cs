using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.PublicDTOs;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.PublicQueries
{
    public class GetAllPublicFooterQuery :IRequest<IDataResponse<List<PublicFooterView>>>
    {
        public class GetAllPublicFooterQueryHandler:IRequestHandler<GetAllPublicFooterQuery,IDataResponse<List<PublicFooterView>>>
        {
            IFooterRepository _footerRepository;
            private readonly IMapper _mapper;
            public GetAllPublicFooterQueryHandler(IFooterRepository footerRepository,IMapper mapper)
            {
                _footerRepository = footerRepository;
                _mapper = mapper;
            }

            public async Task<IDataResponse<List<PublicFooterView>>> Handle(GetAllPublicFooterQuery request, CancellationToken cancellationToken)
            {
                var footer = await _footerRepository.GetAllPublicAsync();
                var viewModel = _mapper.Map<List<PublicFooterView>>(footer);
                return new SuccessServiceResponse<List<PublicFooterView>>(viewModel);
            }
        }
    }
}
