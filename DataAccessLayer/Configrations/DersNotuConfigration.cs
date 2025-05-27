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
    internal class DersNotuConfigration : IEntityTypeConfiguration<DersNotu>
    {
        public void Configure(EntityTypeBuilder<DersNotu> builder)
        {
            builder.HasKey(x => x.DersNotuID);
            builder.ToTable("DersNotu");
            builder.Property(x=>x.DersID).IsRequired();
            builder.Property(x => x.OgretmenID).IsRequired();
            builder.Property(x => x.NotBaslıgı).HasColumnType("varchar(100)");
            builder.Property(x => x.DosyaYolu).HasColumnType("varchar(MAX)");
            builder.Property(x => x.YuklemeTarih).HasColumnType("datetime2");


            builder.HasOne(x => x.Ders)
                .WithMany(x => x.DersNotlar)
                .HasForeignKey(x => x.DersID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Ogretmen)
                .WithMany(x => x.DerslerNotlari)
                .HasForeignKey(x => x.OgretmenID)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
