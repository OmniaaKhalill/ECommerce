using E_Commerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Data.Config
{
    internal class OrderConfigration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o=>o.TotalPrice).IsRequired().HasColumnType("decimal(18,2)");
            //builder.HasOne(o=>o.cart).WithMany().HasForeignKey(o=>o.cartId);
            //builder.HasOne(o => o.user).WithMany().HasForeignKey(o => o.UserId);
        }

      
    
    
    }
}
