using MediatR;
using SmartOtomasyonWebApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Features.Commands.CreateWorkImage
{
    public class CreateWorkImageCommand : IRequest<ServiceResponse<Guid>>
    {
        public String Name { get; set; }
        public String Uri { get; set; }
        public Guid ImageCategoryId { get; set; }

    }
}
