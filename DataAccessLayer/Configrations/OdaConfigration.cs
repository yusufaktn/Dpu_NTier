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
    internal class OdaConfigration : IEntityTypeConfiguration<Oda>
    {
        public void Configure(EntityTypeBuilder<Oda> builder)
        {
            
            builder.HasKey(x => x.OdaID);
            builder.ToTable("Odalar");
            builder.Property(x => x.OdaAdı).HasColumnType("varchar(80)");
            builder.Property(x => x.Aciklama).HasColumnType("varchar(150)");
            builder.Property(x => x.UserID).IsRequired();
            builder.Property(x => x.BolumID).IsRequired();

            builder.HasMany(x => x.OdaMesajları)
                .WithOne(x => x.Oda)
                .HasForeignKey(x => x.OdaID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Bolum)
                .WithMany(x => x.Odalar)
                .HasForeignKey(x => x.BolumID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Odalar)
                .HasForeignKey(x => x.UserID)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
