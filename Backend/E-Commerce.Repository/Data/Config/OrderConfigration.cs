using E_Commerce.Core.Entities;
using E_Commerce.Core.Entities.Oreder_Agrigate;
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
    internal class OrderConfigration : IEntityTypeConfiguration<Core.Entities.Oreder_Agrigate.Order>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Oreder_Agrigate.Order> builder)
        {
            //builder.Property(o=>o.TotalPrice).IsRequired().HasColumnType("decimal(18,2)");
            //builder.HasOne(o=>o.cart).WithMany().HasForeignKey(o=>o.cartId);
            //builder.HasOne(o => o.user).WithMany().HasForeignKey(o => o.UserId);


            builder.OwnsOne(o => o.ShippingAddress, ShippingAddress => ShippingAddress.WithOwner());
            builder.Property(O => O.Status).HasConversion(

                OStatus => OStatus.ToString(),
                OStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), OStatus)
            );

            builder.Property(O => O.SubTotal)


                    .HasColumnType("decimal(18,2)");




            builder.HasOne(O => O.DeliveryMethod)
                 .WithMany()
             .OnDelete(DeleteBehavior.NoAction);


        }

      
    
    
    }
}
