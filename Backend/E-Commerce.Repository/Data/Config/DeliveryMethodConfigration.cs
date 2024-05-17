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
    internal class DeliveryMethodConfigration : IEntityTypeConfiguration<DeliveryMethod>
    {
    

        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            builder.Property(DeliveryMethod => DeliveryMethod.Cost)
                .HasColumnType("decimal(18,2)");

       
        }
    }
  
}
