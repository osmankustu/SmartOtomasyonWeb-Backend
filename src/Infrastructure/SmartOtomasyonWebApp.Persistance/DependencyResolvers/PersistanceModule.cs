using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using SmartOtomasyonWebApp.Application.Interfaces.Repository;
using SmartOtomasyonWebApp.Application.Utilities.Interceptors;
using SmartOtomasyonWebApp.Persistance.Context;
using SmartOtomasyonWebApp.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Persistance.DependencyResolvers
{
    public class PersistanceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<ProductRepository>().As<IProductRepository>().SingleInstance();
            builder.RegisterType<ProductCategoryRepository>().As<IProductCategoryRepository>().SingleInstance();
            builder.RegisterType<WorkImageCategoryRepository>().As<IWorkImageCategoryRepository>().SingleInstance();
            builder.RegisterType<WorkImagesRepository>().As<IWorkImagesRepository>().SingleInstance();
            builder.RegisterType<AboutRepository>().As<IAboutRepository>().SingleInstance();
            builder.RegisterType<ReferanceRepository>().As<IReferanceRepository>().SingleInstance();
            builder.RegisterType<FooterRepository>().As<IFooterRepository>().SingleInstance();
            builder.RegisterType<SocialLinksRepository>().As<ISocialLinksRepository>().SingleInstance();
            builder.RegisterType<PhoneNumberRepository>().As<IPhoneNumberRepository>().SingleInstance();
            builder.RegisterType<MetaRepository>().As<IMetaRepository>().SingleInstance();
            builder.RegisterType<PageRepository>().As<IPagesRepository>().SingleInstance();
            builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();
            builder.RegisterType<UserOperationClaimRepository>().As<IUserOperationClaimRepository>().SingleInstance();
            builder.RegisterType<HomeRepository>().As<IHomeRepository>().SingleInstance();
            builder.RegisterType<CenterContentRepository>().As<ICenterContentRepository>().SingleInstance(); 
            builder.RegisterType<PartnerRepository>().As<IPartnerRepository>().SingleInstance();
            builder.RegisterType<MainSliderRepository>().As<IMainSliderRepository>().SingleInstance();






            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
