using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SmartOtomasyonWebApp.Application.Dto;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Utilities.IoC;
using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Extensions
{
    public class IPServiceExtension : IIPHelper
    {
        private IHttpContextAccessor _httpContextAccessor;
        private IVisitorsRepository _visitor;
        private readonly IMapper _mapper;
        public IPServiceExtension(IHttpContextAccessor httpContextAccessor,IVisitorsRepository visitors,IMapper mapper)
        {
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            _visitor = visitors;
            _mapper = mapper;
        }

        public async Task GetIpAddress(String Content)
        {
            IPAddress remoteIpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress;
            string result = "";
            if (remoteIpAddress != null)
            {
                
                if (remoteIpAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                {
                    remoteIpAddress = System.Net.Dns.GetHostEntry(remoteIpAddress).AddressList
            .First(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
                }
                result = remoteIpAddress.ToString();
            }
            if(await VisitorIsLoggedExist(result,Content))
            {
                var url = $"https://freeipapi.com/api/json/31.155.253.146";
                using (HttpClient client = new())
                {
                    var serializerOptions = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };
                    HttpResponseMessage response = await client.GetAsync(url);
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var res = JsonSerializer.Deserialize<VisitorsDto>(await response.Content.ReadAsStringAsync());
                    res.OnContent = Content;
                    res.CreateAt = DateTime.Now;
                    var visitors = _mapper.Map<Visitors>(res);
                    await _visitor.AddVisitorAsync(visitors);

                }

            }
            
        }

        private async Task<bool> VisitorIsLoggedExist(String ip,string content)
        {
           if(content =="Admin Login")
            {
                return true;
            }
            else
            {
                var ipList = await _visitor.GetAllDateNowVisitorAsync();
                foreach (var visitor in ipList)
                {
                    if (visitor.IpAddress == ip)
                    {
                        return false;
                    }
                }

            }
            return true;
        }
    }
}
