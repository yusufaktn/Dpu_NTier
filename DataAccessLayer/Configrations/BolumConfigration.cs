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
    internal class BolumConfigration : IEntityTypeConfiguration<Bolum>
    {
        public void Configure(EntityTypeBuilder<Bolum> builder)
        {
            builder.HasKey(x => x.ID);
            builder.ToTable("Bolumler");
            builder.Property(x => x.BolumAd).HasColumnType("varchar(100)");
            builder.Property(x=>x.FakulteID).IsRequired();


            builder.HasMany(x => x.Dersler)
                .WithOne(x => x.Bolum)
                .HasForeignKey(x => x.BolumID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Fakulte)
                .WithMany(x => x.Bolumler)
                .HasForeignKey(x => x.FakulteID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Odalar)
                .WithOne(x => x.Bolum)
                .HasForeignKey(x => x.BolumID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.AppUsers)
                .WithOne(x => x.Bolum)
                .HasForeignKey(x => x.BolumID)
                .OnDelete(DeleteBehavior.NoAction);



        }
    }


}
