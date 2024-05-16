using E_Commerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Data.Config
{
    public class ProductConfigration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.Property(p => p.name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.description).IsRequired();
            builder.Property(p => p.image_link).IsRequired();
            builder.Property(p => p.price).IsRequired().HasColumnType("decimal(18,2)");
            //builder.HasOne(p => p.Category).WithMany().HasForeignKey(p => p.CategoryId);
            //builder.HasOne(p => p.seller).WithMany().HasForeignKey(p => p.SellerId);

            



        }
    }
}
