using AutoMapper;
using SmartOtomasyonWebApp.Application.Dto;
using SmartOtomasyonWebApp.Application.Dto.About;
using SmartOtomasyonWebApp.Application.Dto.CenterContentDto;
using SmartOtomasyonWebApp.Application.Dto.DocumentCategoryDto;
using SmartOtomasyonWebApp.Application.Dto.DocumentDto;
using SmartOtomasyonWebApp.Application.Dto.EndContentDto;
using SmartOtomasyonWebApp.Application.Dto.Footer;
using SmartOtomasyonWebApp.Application.Dto.HomeDto;
using SmartOtomasyonWebApp.Application.Dto.Mail;
using SmartOtomasyonWebApp.Application.Dto.MainSliderDto;
using SmartOtomasyonWebApp.Application.Dto.MetaDto;
using SmartOtomasyonWebApp.Application.Dto.PageDto;
using SmartOtomasyonWebApp.Application.Dto.PartnerDto;
using SmartOtomasyonWebApp.Application.Dto.PhoneNumberDto;
using SmartOtomasyonWebApp.Application.Dto.Product;
using SmartOtomasyonWebApp.Application.Dto.ProductCategory;
using SmartOtomasyonWebApp.Application.Dto.PublicDTOs;
using SmartOtomasyonWebApp.Application.Dto.Referance;
using SmartOtomasyonWebApp.Application.Dto.SocialLink;
using SmartOtomasyonWebApp.Application.Dto.WorkImage;
using SmartOtomasyonWebApp.Application.Dto.WorkImageCategoryDto;
using SmartOtomasyonWebApp.Application.Features.Commands.AboutCommands;
using SmartOtomasyonWebApp.Application.Features.Commands.CenterContentCommands;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateAbout;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateCommands.CreateCenterContent;
using SmartOtomasyonWebApp.Application.Features.Commands.CreateCommands.CreateHome;
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
using SmartOtomasyonWebApp.Application.Features.Commands.DocumentCategoryCommands;
using SmartOtomasyonWebApp.Application.Features.Commands.DocumentCommands;
using SmartOtomasyonWebApp.Application.Features.Commands.EndContentCommands;
using SmartOtomasyonWebApp.Application.Features.Commands.FooterCommands;
using SmartOtomasyonWebApp.Application.Features.Commands.HomeCommands;
using SmartOtomasyonWebApp.Application.Features.Commands.MailCommands;
using SmartOtomasyonWebApp.Application.Features.Commands.MainSliderCommands;
using SmartOtomasyonWebApp.Application.Features.Commands.MetaCommands;
using SmartOtomasyonWebApp.Application.Features.Commands.PageCommands;
using SmartOtomasyonWebApp.Application.Features.Commands.PartnerCommands;
using SmartOtomasyonWebApp.Application.Features.Commands.PhoneNumberCommands;
using SmartOtomasyonWebApp.Application.Features.Commands.ProductCategoryCommands;
using SmartOtomasyonWebApp.Application.Features.Commands.ProductCommands;
using SmartOtomasyonWebApp.Application.Features.Commands.ReferanceCommands;
using SmartOtomasyonWebApp.Application.Features.Commands.SocialLinkCommands;
using SmartOtomasyonWebApp.Application.Features.Commands.WorkImageCategoryCommands;
using SmartOtomasyonWebApp.Application.Features.Commands.WorkImageCommands;
using SmartOtomasyonWebApp.Application.Features.PublicCommands;
using SmartOtomasyonWebApp.Application.Features.PublicQueries.GetByIdQuery;
using SmartOtomasyonWebApp.Application.Features.Queries.GetAboutQueries;
using SmartOtomasyonWebApp.Application.Features.Queries.GetCenterContentQueries;
using SmartOtomasyonWebApp.Application.Features.Queries.GetDocumentCategoryQueries;
using SmartOtomasyonWebApp.Application.Features.Queries.GetDocumentQueries;
using SmartOtomasyonWebApp.Application.Features.Queries.GetEndContentQueries;
using SmartOtomasyonWebApp.Application.Features.Queries.GetFooterQueries;
using SmartOtomasyonWebApp.Application.Features.Queries.GetHomeQueries;
using SmartOtomasyonWebApp.Application.Features.Queries.GetMailQueries;
using SmartOtomasyonWebApp.Application.Features.Queries.GetMainSliderQueries;
using SmartOtomasyonWebApp.Application.Features.Queries.GetPartnerQueries;
using SmartOtomasyonWebApp.Application.Features.Queries.GetPhoneNumberQueries;
using SmartOtomasyonWebApp.Application.Features.Queries.GetProductCategoryQueries;
using SmartOtomasyonWebApp.Application.Features.Queries.GetProductsQueries;
using SmartOtomasyonWebApp.Application.Features.Queries.GetSocialLinksQueries;
using SmartOtomasyonWebApp.Application.Features.Queries.GetWorkImageCategoryQueries;
using SmartOtomasyonWebApp.Application.Features.Queries.GetWorkImageQueries;
using SmartOtomasyonWebApp.Application.Features.Queries.ReferanceQueries;
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
            CreateMap<Product, GetProductByIdQuery>().ReverseMap();
            CreateMap<Product, DeleteProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            //
            CreateMap<ProductCategory, CreateProductCategoryCommand>().ReverseMap();
            CreateMap<ProductCategory, ProductCategoryView>().ReverseMap();
            CreateMap<ProductCategory, DeleteProductCategoryCommand>().ReverseMap();
            CreateMap<ProductCategory,UpdateProductCategoryCommand>().ReverseMap();
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
            //
            CreateMap<Home, HomeView>().ReverseMap();
            CreateMap<Home, CreateHomeCommand>().ReverseMap();
            CreateMap<Home, DeleteHomeCommand>().ReverseMap();
            CreateMap<Home, UpdateHomeCommand>().ReverseMap();
            CreateMap<Home, GetByIdHomeQuery>().ReverseMap();
            //
            CreateMap<CenterContent, CenterContentView>().ReverseMap();
            CreateMap<CenterContent, CreateCenterContentCommand>().ReverseMap();
            CreateMap<CenterContent, DeleteCenterContentCommand>().ReverseMap();
            CreateMap<CenterContent, GetByIdCenterContentQuery>().ReverseMap();
            CreateMap<CenterContent, UpdateCenterContentCommand>().ReverseMap();
            //
            CreateMap<Partner, PartnerView>().ReverseMap();
            CreateMap<Partner,CreatePartnerCommand>().ReverseMap();
            CreateMap<Partner,DeletePartnerCommand>().ReverseMap();
            CreateMap<Partner,GetByIdPartnerQuery>().ReverseMap();
            CreateMap<Partner,UpdatePartnerCommand>().ReverseMap();
            //
            CreateMap<MainSlider,MainSliderView>().ReverseMap();
            CreateMap<MainSlider,GetByIdlMainSliderQuery>().ReverseMap();
            CreateMap<MainSlider,CreateMainSliderCommand>().ReverseMap();
            CreateMap<MainSlider,DeleteMainSliderCommand>().ReverseMap();
            CreateMap<MainSlider,UpdateMainSliderCommand>().ReverseMap();
            //
            CreateMap<EndContent,EndContentView>().ReverseMap();
            CreateMap<EndContent,GetByIdEndContentQuery>().ReverseMap();
            CreateMap<EndContent,CreateEndContentCommand>().ReverseMap();
            CreateMap<EndContent,UpdateEndContentCommand>().ReverseMap();
            CreateMap<EndContent,DeleteEndContentCommand>().ReverseMap();
            //
            CreateMap<Visitors, VisitorsDto>().ReverseMap();
            //
            CreateMap<MailBox, DeleteMailCommand>().ReverseMap();
            CreateMap<MailBox, MailView>().ReverseMap();
            CreateMap<MailBox, GetByIdMailQuery>().ReverseMap();
            //
            CreateMap<DocumentCategory, DeleteDocumentCategoryCommand>().ReverseMap();
            CreateMap<DocumentCategory, UpdateDocumentCategoryCommand>().ReverseMap();
            CreateMap<DocumentCategory, CreateDocumentCategoryCommand>().ReverseMap();
            CreateMap<DocumentCategory, DocumentCategoryView>().ReverseMap();
            CreateMap<DocumentCategory, GetByIdDocumentCategoryQuery>().ReverseMap();
            //
            CreateMap<Document, CreateDocumentCommand>().ReverseMap();
            CreateMap<Document, DeleteDocumentCommand>().ReverseMap();
            CreateMap<Document,UpdateDocumentCommand>().ReverseMap();
            CreateMap<Document, DocumentView>().ReverseMap();
            CreateMap<Document, GetByIdDocumentQuery>().ReverseMap();


            //PUBLİC MAP
            CreateMap<Home, PublicHomeView>().ReverseMap();
            CreateMap<About, PublicAboutView>().ReverseMap();
            CreateMap<Referance, PublicReferanceView>().ReverseMap();
            CreateMap<Page, PublicPageView>().ReverseMap();
            CreateMap<Footer,PublicFooterView>().ReverseMap();
            CreateMap<ProductCategory, PublicProductCategoryView>().ReverseMap();
            CreateMap<Product,PublicProductView>().ReverseMap();
            CreateMap<Product, PublicGetByIdProductView>().ReverseMap();
            CreateMap<WorkImages, PublicImageView>().ReverseMap();
            CreateMap<WorkImageCategory,PublicImageCategoryView>().ReverseMap();
            CreateMap<MailBox, CreateMailCommands>().ReverseMap();
            CreateMap<Document, GetByCategoryIdDocumentQuery>().ReverseMap();

        }
    }
}
