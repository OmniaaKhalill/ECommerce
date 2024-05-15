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
    internal class WishListConfigration : IEntityTypeConfiguration<WishList>
    {
        public void Configure(EntityTypeBuilder<WishList> builder)
        {

            //builder.HasOne(w => w.user).WithOne().HasForeignKey<WishList>(w => w.userId);
        }
    }
}
