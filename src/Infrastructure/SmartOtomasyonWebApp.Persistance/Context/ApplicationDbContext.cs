using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Persistance.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //local
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-N6K9MD1;Database=SmartOtomasyonWeb;Trusted_Connection=true;TrustServerCertificate=True");
            //production
            optionsBuilder.UseSqlServer(@"Server=*;Database=SmartOtomasyonWeb;user id=*;pwd=*;Trusted_Connection=false;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductsCategory { get; set; }
        public DbSet<WorkImages> WorkImages { get; set; }
        public DbSet<WorkImageCategory> WorkImageCategory { get; set; }
        public DbSet<MainSlider> MainSlider { get; set; }
        public DbSet<PhoneNumber> PhoneNumber { get; set; }
        public DbSet<SocialLinks>  SocialLinks { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<Footer> Footer { get; set; }
        public DbSet<Referance> Referance { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Meta> Meta { get; set; }

        public DbSet<Home> Home { get; set; }
        public DbSet<CenterContent> CenterContent { get; set; }
        public DbSet<Partner> Partner { get; set; }
        public DbSet<EndContent> EndContent { get; set; }
        //Mail
        public DbSet<MailBox> MailBox { get; set; }

        //document
        public DbSet<Document> Document { get; set; }
        public DbSet<DocumentCategory> DocumentCategory { get; set; }

        //auth
        public DbSet<User> User { get; set; }
        public DbSet<OperationClaim> OperationClaim { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaim { get; set; }
        public DbSet<Visitors> Visitors { get; set; }


       

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
           
        //}
    }
}
