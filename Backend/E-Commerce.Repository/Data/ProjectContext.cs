using E_Commerce.Core.Entities;
using E_Commerce.Core.Entities.Identity;
using E_Commerce.Core.Entities.Oreder_Agrigate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Order = E_Commerce.Core.Entities.Oreder_Agrigate.Order;
using OrderItem = E_Commerce.Core.Entities.Oreder_Agrigate.OrderItem;

namespace E_Commerce.Repository.Data
{
    public class ProjectContext :IdentityDbContext<AppUser>
    {


        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)  //configure option
        { }

        public DbSet<Product> products { get; set; }
        public DbSet<Cart>  cart {  get; set; }
        public DbSet<Category>categories { get; set; }
        public DbSet<Coulor> colors { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> Orderitems { get; set; }

        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }

        public DbSet<Page>Pages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<Seller> sellers { get; set; }

        public DbSet<WishList> wishlist { get; set; }


        public DbSet<Brands> brandss { get; set; }



        //==> create dbset for  
        //order(s)
        //OrderItem(s)
        //DeliveryMethod(s) 




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Seller>()
                .HasOne(s => s.Page)
                .WithOne(p => p.seller)
                .HasForeignKey<Page>(p => p.SellerId);


        }

    }

}
