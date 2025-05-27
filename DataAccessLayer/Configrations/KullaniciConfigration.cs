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
    internal class KullaniciConfigration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("Kullanici");
            builder.HasKey(x => x.Id); // Id anahtarını belirtiyoruz


            builder.HasOne(x => x.Bolum)
                .WithMany(x => x.AppUsers)
                .HasForeignKey(x => x.BolumID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Odalar)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.OdaMesajları)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserID)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
