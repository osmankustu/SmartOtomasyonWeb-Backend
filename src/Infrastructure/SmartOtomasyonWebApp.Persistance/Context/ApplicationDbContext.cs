﻿using Microsoft.EntityFrameworkCore;
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
       // public DbSet<Product> Products {get;set;}
       //NAVBAR
        public DbSet<Navbar> Navbar { get; set; }
        public DbSet<NavbarCategory> NavbarCategory { get; set; }
        //PRODUCTS
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductsCategory { get; set; }
        //IMAGES GALLEY
        public DbSet<WorkImages> WorkImages { get; set; }
        public DbSet<WorkImageCategory> WorkImageCategory { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-N6K9MD1;Database=SmartOtomasyonWeb;Trusted_Connection=true;TrustServerCertificate=True");
           
            base.OnConfiguring(optionsBuilder); 

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
           
        //}
    }
}
