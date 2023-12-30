using MediatR;
using SmartOtomasyonWebApp.Application.Dto;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Queries.GetProductById
{
    public class GetProductByIdQuery :IRequest<ServiceResponse<GetProductByIdViewModel>>
    {
        public Guid Id { get; set; }
    }
}
