
using Microsoft.Extensions.DependencyInjection;
using SmartOtomasyonWebApp.Application.Utilities.IoC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Extensions
{
    public static class ServiceCollectionExtensions 
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);

            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}
