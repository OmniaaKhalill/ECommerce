using E_Commerce.Core.Entities;
using E_Commerce.Core.Entities.Oreder_Agrigate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Data.Config
{
    internal class OrderItemConfigration : IEntityTypeConfiguration<Core.Entities.Oreder_Agrigate.OrderItem>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Oreder_Agrigate.OrderItem> builder)
        {

            //builder.HasOne(o=>o.Product).WithMany().HasForeignKey(o=>o.ProductId);
            //builder.HasOne(o => o.Order).WithMany().HasForeignKey(o => o.OrderId);


            builder.OwnsOne(orderItem => orderItem.Product, product =>
            {
                product.WithOwner();
            });


            builder.Property(orderItem => orderItem.Price)
                .HasColumnType("decimal(18,2)");


          




        }
    }
}
