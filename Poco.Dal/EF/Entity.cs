using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Poco.Model.Models;

namespace Poco.Dal.EF
{
    public class Entity : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public Entity(DbContextOptions<Entity> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //configuration commands
            optionsBuilder.UseLazyLoadingProxies();
            //enable lazy loading proxies
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // primary join
            builder.Entity<OrderProduct>().HasKey(o => new { o.OrderId, o.ProductId });
            builder.Entity<User>()
               .ToTable("AspNetUsers")
               .HasDiscriminator<int>("UserType")
               .HasValue<User>(0);


            // builder.Entity<User>()
            // .ToTable("AspNetUsers")
            // .HasDiscriminator<int>("UserType")
            // .HasValue<User>(0);



        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }



    }
}