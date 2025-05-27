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
    internal class OgretmenConfigration : IEntityTypeConfiguration<Ogretmen>
    {
        public void Configure(EntityTypeBuilder<Ogretmen> builder)
        {
            builder.HasKey(x => x.ID);
            builder.ToTable("Ogretmenler");
            builder.Property(x => x.Ad).HasColumnType("varchar(50)");
            builder.Property(x => x.Soyad).HasColumnType("varchar(50)");
            builder.Property(x => x.Eposta).HasColumnType("varchar(100)");
            builder.Property(x => x.Telefon).HasColumnType("varchar(14)");

            builder.HasMany(x => x.DerslerNotlari) // Bir öğretmenin birden fazla ders notu olabilir
                .WithOne(x => x.Ogretmen) // Karşılık olarak bir ders notunun sadece bir öğretmeni vardır
                .HasForeignKey(x => x.OgretmenID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.OgretmenDersleri)// Bir öğretmenin birden fazla dersi olabilir
                .WithOne(x => x.Ogretmen) // Karşılık olarak bir dersin sadece bir öğretmeni vardır
                .HasForeignKey(x => x.OgretmenID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
