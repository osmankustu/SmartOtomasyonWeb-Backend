using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Persistance.Context;
using SmartOtomasyonWebApp.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceRegistration(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer());
            serviceCollection.AddTransient<IProductRepository, ProductRepository>();
            serviceCollection.AddTransient<INavbarRepository,NavbarRepository>();
            serviceCollection.AddTransient<INavbarCategoryRepository, NavbarCategoryRepository>();
            serviceCollection.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            serviceCollection.AddTransient<IWorkImageCategoryRepository, WorkImageCategoryRepository>();
            serviceCollection.AddTransient<IWorkImagesRepository, WorkImagesRepository>();
        }
    }
}
