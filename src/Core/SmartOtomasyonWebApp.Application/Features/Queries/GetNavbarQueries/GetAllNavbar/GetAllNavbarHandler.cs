using AutoMapper;
using MediatR;
using SmartOtomasyonWebApp.Application.Dto.NavbarCategory;
using SmartOtomasyonWebApp.Application.Features.Queries.GetAllProducts;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetNavbarCategory
{
    public class GetAllNavbarHandler : IRequestHandler<GetAllNavbarQuery, ServiceResponse<List<NavbarView>>>
    {
        private readonly INavbarRepository _navbarRepository;
        private readonly IMapper _mapper;
        public GetAllNavbarHandler(INavbarRepository navbarRepository, IMapper mapper)
        {
            _navbarRepository = navbarRepository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<NavbarView>>> Handle(GetAllNavbarQuery request, CancellationToken cancellationToken)
        {

            var list = await _navbarRepository.AsyncJoinedNavbarCategories();
            
            var map = _mapper.Map<List<NavbarView>>(list);
            return new ServiceResponse<List<NavbarView>>(map);
        }
    }
}
