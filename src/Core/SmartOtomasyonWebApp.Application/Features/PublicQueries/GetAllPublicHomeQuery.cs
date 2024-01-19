using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SmartOtomasyonWebApp.Application.Dto;
using SmartOtomasyonWebApp.Application.Dto.PublicDTOs;
using SmartOtomasyonWebApp.Application.Extensions;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Utilities.IoC;
using SmartOtomasyonWebApp.Application.Wrappers;
using SmartOtomasyonWebApp.Application.Wrappers.Abstract;
using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.PublicQueries
{
    public class GetAllPublicHomeQuery : IRequest<IDataResponse<PublicHomeView>>
    {
        public class GetAllPublicHomeQueryHandler : IRequestHandler<GetAllPublicHomeQuery,IDataResponse<PublicHomeView>>
        {
            IHomeRepository _homeRepository;
            private readonly IMapper _mapper;
            IIPHelper _ipService;
            public GetAllPublicHomeQueryHandler(IHomeRepository homeRepository, IMapper mapper,IIPHelper serviceHelper)
            {
                _homeRepository = homeRepository;
                _mapper = mapper;
                _ipService = serviceHelper;
            }

            public async Task<IDataResponse<PublicHomeView>> Handle(GetAllPublicHomeQuery request, CancellationToken cancellationToken)
            {
                await _ipService.GetIpAddress();
                var homes =  _homeRepository.GetAllPublicAsync().Result.First();
                var viewModel = _mapper.Map<PublicHomeView>(homes);
                return new SuccessServiceResponse<PublicHomeView>(viewModel);
            }
        }

        
    }
}
