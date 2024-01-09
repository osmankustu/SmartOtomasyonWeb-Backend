using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using Castle.DynamicProxy;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SmartOtomasyonWebApp.Application.Utilities.Interceptors;
using SmartOtomasyonWebApp.Application.Utilities.IoC;
using SmartOtomasyonWebApp.Application.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.DependencyResolvers
{
    public class ApplicationModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            var assmbly = System.Reflection.Assembly.GetExecutingAssembly();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ITokenHelper, JwtHelper>();
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}
