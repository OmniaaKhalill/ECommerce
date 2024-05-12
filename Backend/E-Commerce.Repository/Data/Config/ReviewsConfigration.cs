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
    internal class ReviewsConfigration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            //builder.HasOne(r => r.User).WithMany().HasForeignKey(r=>r.UserId);
            //builder.HasOne(r => r.Product).WithMany().HasForeignKey(r => r.ProductId);
        }
    }
}
