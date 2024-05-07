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
    internal class OrderItemConfigration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            
            //builder.HasOne(o=>o.Product).WithMany().HasForeignKey(o=>o.ProductId);
            //builder.HasOne(o => o.Order).WithMany().HasForeignKey(o => o.OrderId);


        }
    }
}
