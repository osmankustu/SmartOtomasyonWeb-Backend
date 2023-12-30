using AutoMapper;
using SmartOtomasyonWebApp.Application.Dto.NavbarCategory;
using SmartOtomasyonWebApp.Application.Dto.Product;
using SmartOtomasyonWebApp.Application.Dto.ProductCategory;
using SmartOtomasyonWebApp.Application.Dto.WorkImage;
using SmartOtomasyonWebApp.Application.Dto.WorkImageCategory;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateNavbar;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateNavbarCategory;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateProduct;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateProductCategory;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateWorkImage;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateWorkImageCategory;
using SmartOtomasyonWebApp.Application.Features.Queries.GetProductById;
using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Product,ProductViewDto>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, GetProductByIdViewModel>().ReverseMap();
            CreateMap<Navbar, NavbarView>().ReverseMap();
            CreateMap<Navbar, CreateNavbarCommand>().ReverseMap();
            CreateMap<NavbarCategory, CreateNavbarCategoryCommand>().ReverseMap();
            CreateMap<NavbarCategory, NavbarCategoryView>().ReverseMap();
            CreateMap<ProductCategory, CreateProductCategoryCommand>().ReverseMap();
            CreateMap<ProductCategory, ProductCategoryView>().ReverseMap();
            CreateMap<WorkImageCategory, CreateWorkImageCategoryCommand>().ReverseMap();
            CreateMap<WorkImageCategory, WorkImageCategoryView>().ReverseMap();
            CreateMap<WorkImages, CreateWorkImageCommand>().ReverseMap();
            CreateMap<WorkImages, WorkImageView>().ReverseMap();
            
        }
    }
}
