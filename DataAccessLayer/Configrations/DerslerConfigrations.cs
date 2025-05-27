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
    internal sealed class DerslerConfigrations : IEntityTypeConfiguration<Dersler>
    {
        public void Configure(EntityTypeBuilder<Dersler> builder)
        {
            builder.HasKey(x => x.DersID);
            builder.ToTable("Dersler");
            builder.Property(x => x.DersAd).HasColumnType("varchar(100)");
            builder.Property(x => x.Donem).HasColumnType("varchar(50)");
            builder.Property(x => x.BolumID).IsRequired();
            builder.Property(x=>x.DersID).IsRequired();

            builder.HasOne(x => x.Bolum)// Bir dersin sadece bir bölümü olduğunu belirtir
                .WithMany(x => x.Dersler)//Karşılık olarak bir bölümün birden fazla dersi olabilir
                .HasForeignKey(x => x.BolumID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.DersNotlar)//Bir dersin birden fazla notu olabilir
                .WithOne(x => x.Ders)//Karşılık olarak bir notun sadece bir dersi vardır
                .HasForeignKey(x => x.DersID)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
