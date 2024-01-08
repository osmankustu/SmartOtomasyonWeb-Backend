using AutoMapper;
using SmartOtomasyonWebApp.Application.Dto.About;
using SmartOtomasyonWebApp.Application.Dto.Footer;
using SmartOtomasyonWebApp.Application.Dto.MetaDto;
using SmartOtomasyonWebApp.Application.Dto.PageDto;
using SmartOtomasyonWebApp.Application.Dto.PhoneNumberDto;
using SmartOtomasyonWebApp.Application.Dto.Product;
using SmartOtomasyonWebApp.Application.Dto.ProductCategory;
using SmartOtomasyonWebApp.Application.Dto.PublicDTOs;
using SmartOtomasyonWebApp.Application.Dto.Referance;
using SmartOtomasyonWebApp.Application.Dto.SocialLink;
using SmartOtomasyonWebApp.Application.Dto.WorkImage;
using SmartOtomasyonWebApp.Application.Dto.WorkImageCategoryDto;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateAbout;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateCommands.CreateMeta;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateCommands.CreatePage;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateCommands.CreatePhoneNumber;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateFooter;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateProduct;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateProductCategory;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateReferance;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateSocialLink;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateWorkImage;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateWorkImageCategory;
using SmartOtomasyonWebApp.Application.Features.Commands.DeleteCommands.DeleteAbout;
using SmartOtomasyonWebApp.Application.Features.Commands.DeleteCommands.DeleteFooter;
using SmartOtomasyonWebApp.Application.Features.Commands.DeleteCommands.DeleteMeta;
using SmartOtomasyonWebApp.Application.Features.Commands.DeleteCommands.DeletePage;
using SmartOtomasyonWebApp.Application.Features.Commands.DeleteCommands.DeletePhoneNumber;
using SmartOtomasyonWebApp.Application.Features.Commands.DeleteCommands.DeleteProduct;
using SmartOtomasyonWebApp.Application.Features.Commands.DeleteCommands.DeleteProductCategory;
using SmartOtomasyonWebApp.Application.Features.Commands.DeleteCommands.DeleteReferance;
using SmartOtomasyonWebApp.Application.Features.Commands.DeleteCommands.DeleteSocialLink;
using SmartOtomasyonWebApp.Application.Features.Commands.DeleteCommands.DeleteWorkImageCategory;
using SmartOtomasyonWebApp.Application.Features.Commands.DeleteCommands.DeleteWorkImages;
using SmartOtomasyonWebApp.Application.Features.Commands.UpdateCommands;
using SmartOtomasyonWebApp.Application.Features.Commands.UpdateCommands.UpdateAbout;
using SmartOtomasyonWebApp.Application.Features.Commands.UpdateCommands.UpdateFooter;
using SmartOtomasyonWebApp.Application.Features.Commands.UpdateCommands.UpdatePage;
using SmartOtomasyonWebApp.Application.Features.Commands.UpdateCommands.UpdatePhoneNumber;
using SmartOtomasyonWebApp.Application.Features.Commands.UpdateCommands.UpdateProduct;
using SmartOtomasyonWebApp.Application.Features.Commands.UpdateCommands.UpdateReferance;
using SmartOtomasyonWebApp.Application.Features.Commands.UpdateCommands.UpdateSocialLink;
using SmartOtomasyonWebApp.Application.Features.Commands.UpdateCommands.UpdateWorkImage;
using SmartOtomasyonWebApp.Application.Features.Commands.UpdateCommands.UpdateWorkImageCategory;
using SmartOtomasyonWebApp.Application.Features.Queries.GetAboutQueries.GetByIdAAbout;
using SmartOtomasyonWebApp.Application.Features.Queries.GetFooterQueries.GetByIdFooter;
using SmartOtomasyonWebApp.Application.Features.Queries.GetPhoneNumberQueries.GetByIdPhoneNumber;
using SmartOtomasyonWebApp.Application.Features.Queries.GetProductById;
using SmartOtomasyonWebApp.Application.Features.Queries.GetProductCategoryQueries.GetByIdProductCategory;
using SmartOtomasyonWebApp.Application.Features.Queries.GetSocialLinksQueries.GetByIdSocialLink;
using SmartOtomasyonWebApp.Application.Features.Queries.GetWorkImageCategoryQueries.GetByIdWorkImageCategory;
using SmartOtomasyonWebApp.Application.Features.Queries.GetWorkImageQueries.GetByIdWorkImage;
using SmartOtomasyonWebApp.Application.Features.Queries.ReferanceQueries.GetByIdReferance;
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
            
            
           
          
            
            
            //
            CreateMap<Referance, CreateReferanceCommand>().ReverseMap();
            CreateMap<Referance, DeleteReferanceCommand>().ReverseMap();
            CreateMap<Referance, UpdateReferanceCommand>().ReverseMap();
            CreateMap<Referance, ReferanceView>().ReverseMap();
            CreateMap<Referance, GetByIdReferanceQuery>().ReverseMap();
            //
            CreateMap<WorkImageCategory, CreateWorkImageCategoryCommand>().ReverseMap();
            CreateMap<WorkImageCategory, WorkImageCategoryView>().ReverseMap();
            CreateMap<WorkImageCategory, DeleteWorkImageCategoryCommand>().ReverseMap();
            CreateMap<WorkImageCategory, GetByIdWorkImageCategoryQuery>().ReverseMap();
            CreateMap<WorkImageCategory, UpdateWorkImageCategoryCommand>().ReverseMap();
            //
            CreateMap<WorkImages, CreateWorkImageCommand>().ReverseMap();
            CreateMap<WorkImages, WorkImageView>().ReverseMap();
            CreateMap<WorkImages, UpdateWorkImageCommand>().ReverseMap();
            CreateMap<WorkImages, GetByIdWorkImageQuery>().ReverseMap();
            CreateMap<WorkImages, DeleteWorkImagesCommand>().ReverseMap();
            //
            CreateMap<About, AboutView>().ReverseMap();
            CreateMap<About, CreateAboutCommand>().ReverseMap();
            CreateMap<About, GetByIdAboutQuery>().ReverseMap();
            CreateMap<About, UpdateAboutCommand>().ReverseMap();
            CreateMap<About, DeleteAboutCommand>().ReverseMap();
            //
            CreateMap<Footer, CreateFooterCommand>().ReverseMap();
            CreateMap<Footer, FooterView>().ReverseMap();
            CreateMap<Footer, UpdateFooterCommand>().ReverseMap();
            CreateMap<Footer, GetByIdFooterQuery>().ReverseMap();
            CreateMap<Footer, DeleteFooterCommand>().ReverseMap();
            //
            CreateMap<PhoneNumber, PhoneNumberView>().ReverseMap();
            CreateMap<PhoneNumber, GetByIdPhoneNumberQuery>().ReverseMap();
            CreateMap<PhoneNumber, CreatePhoneNumberCommand>().ReverseMap();
            CreateMap<PhoneNumber, UpdatePhoneNumberCommand>().ReverseMap();
            CreateMap<PhoneNumber, DeletePhoneNumberCommand>().ReverseMap();
            //
            CreateMap<SocialLinks, CreateSocialLinkCommand>().ReverseMap();
            CreateMap<SocialLinks, SocialLinkView>().ReverseMap();
            CreateMap<SocialLinks, GetByIdSocialLinkQuery>().ReverseMap();
            CreateMap<SocialLinks, DeleteSocialLinkCommand>().ReverseMap();
            CreateMap<SocialLinks, UpdateSocialLinkCommand>().ReverseMap();
            //
            CreateMap<Product, ProductViewDto>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, GetProductByIdViewModel>().ReverseMap();
            CreateMap<Product, DeleteProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            //
            CreateMap<ProductCategory, CreateProductCategoryCommand>().ReverseMap();
            CreateMap<ProductCategory, ProductCategoryView>().ReverseMap();
            CreateMap<ProductCategory, DeleteProductCategoryCommand>().ReverseMap();
            CreateMap<ProductCategory,UpdateProductCommand>().ReverseMap();
            CreateMap<ProductCategory, GetByIdProductCategoryQuery>().ReverseMap();
            //
            CreateMap<Page, PageView>().ReverseMap();
            CreateMap<Page, DeletePageCommand>().ReverseMap();
            CreateMap<Page, UpdatePageCommand>().ReverseMap();
            CreateMap<Page, CreatePageCommand>().ReverseMap();
            //
            CreateMap<Meta, MetaView>().ReverseMap();
            CreateMap<Meta, CreateMetaCommand>().ReverseMap();
            CreateMap<Meta, DeleteMetaCommand>().ReverseMap();
            CreateMap<Meta, UpdateMetaCommand>().ReverseMap();

            //PUBLİC MAP
            CreateMap<About, PublicAboutView>().ReverseMap();
            CreateMap<Referance, PublicReferanceView>().ReverseMap();
            CreateMap<Page, PublicPageView>().ReverseMap();
        }
    }
}
