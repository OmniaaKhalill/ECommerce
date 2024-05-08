using E_Commerce.Core.Entities;
using E_Commerce.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
        public DbSet<Page>Pages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<Seller> sellers { get; set; }

        public DbSet<Tag> tags { get; set; }
        public DbSet<WishList> wishlist { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Seller>()
                .HasOne(s => s.Page)
                .WithOne(p => p.Seller)
                .HasForeignKey<Page>(p => p.SellerId);


        }

    }

}
