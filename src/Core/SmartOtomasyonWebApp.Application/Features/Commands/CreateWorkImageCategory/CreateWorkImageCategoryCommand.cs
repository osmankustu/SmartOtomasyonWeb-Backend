using MediatR;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Commands.CreateWorkImageCategory
{
    public class CreateWorkImageCategoryCommand :IRequest<ServiceResponse<Guid>>
    {
        public String Name { get; set; }
    }
}
