using E_Commerce.Core.Entities;
using E_Commerce.Core.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Data.Config
{
    public class SellerConfigration
    {

        public void Configure(EntityTypeBuilder<Seller> builder)
        {

        builder
       .HasOne(s => s.AppUser)
       .WithOne(u => u.Seller)
       .HasForeignKey<Seller>(s => s.UserId);


        }
    }
}
