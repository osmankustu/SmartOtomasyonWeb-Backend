using MediatR;
using SmartOtomasyonWebApp.Application.Dto.NavbarCategory;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetNavbarCategory
{
    public class GetAllNavbarQuery :IRequest<ServiceResponse<List<NavbarView>>>
    {
        
    }
}
