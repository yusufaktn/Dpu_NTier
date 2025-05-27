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
    internal class FakulteConfigration : IEntityTypeConfiguration<Fakulte>
    {
        public void Configure(EntityTypeBuilder<Fakulte> builder)
        {
            builder.HasKey(x => x.ID);
            builder.ToTable("Fakulte");
            builder.Property(x => x.FakülteAd)
                .IsRequired()
                .HasColumnType("varchar(100)");
            builder.Property(x => x.UniversiteID).IsRequired();

            builder.HasOne(x => x.Universite)
                .WithMany(x => x.Fakulteler)
                .HasForeignKey(x => x.UniversiteID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Bolumler)
                .WithOne(x => x.Fakulte)
                .HasForeignKey(x => x.FakulteID)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
