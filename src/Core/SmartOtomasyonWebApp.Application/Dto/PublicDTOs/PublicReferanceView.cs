using MediatR;
using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Dto.PublicDTOs
{
    public class PublicReferanceView 
    {
        public String Title { get; set; }
        public String Description { get; set; }
        public String LogoUri { get; set; }
        public String SiteUri { get; set; }
        public Guid PageId { get; set; }
    }
}
