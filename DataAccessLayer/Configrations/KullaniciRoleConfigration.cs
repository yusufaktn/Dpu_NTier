using EntiityLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Configrations
{
    internal sealed class KullaniciRoleConfigration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.ToTable("KullaniciRole");
            builder.HasKey(x => new {x.RoleId,x.UserId});//Kompozit anahtar yani birden fazla anahtar var

            
            
        }
    }
}
