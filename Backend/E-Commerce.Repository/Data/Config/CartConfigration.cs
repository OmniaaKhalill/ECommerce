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
    internal class CartConfigration : IEntityTypeConfiguration<Cart>


    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            //builder.HasOne(c => c.user).WithOne().HasForeignKey<Cart>(c => c.userId);
            
        }
    }
}
