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
    internal class PaymentConfigration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(p => p.amount)
               .HasColumnType("decimal(18, 2)");
            //builder.HasOne(p => p.User).WithMany().HasForeignKey(p => p.userId);
            //builder.HasOne(p => p.Order).WithOne().HasForeignKey<Payment>(p => p.orderId);


        }
    }
}
