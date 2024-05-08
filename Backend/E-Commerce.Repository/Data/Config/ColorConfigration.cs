using E_Commerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Data.Config
{
    internal class ColorConfigration : IEntityTypeConfiguration<Coulor>
    {
        public void Configure(EntityTypeBuilder<Coulor> builder)
        {

            //builder.HasOne(c=>c.Product).WithMany().HasForeignKey(c => c.ProductId);
        }
    }
}
