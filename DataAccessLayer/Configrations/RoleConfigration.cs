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
    internal class RoleConfigration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
           builder.ToTable("Role");
           builder.HasKey(x => x.Id); // Id anahtarını belirtiyoruz

            builder.Property(x => x.Name)
              .IsRequired()
              .HasMaxLength(50);



        }
    }
}
