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
    internal class OdaMesajConfigration : IEntityTypeConfiguration<OdaMesajları>
    {
        public void Configure(EntityTypeBuilder<OdaMesajları> builder)
        {
            builder.HasKey(x => x.OdaMesajID);
            builder.ToTable("OdaMesajları");
            builder.Property(x => x.Mesaj).HasColumnType("varchar(500)");
            builder.Property(x => x.DosyaYolu).HasColumnType("varchar(MAX)");

            builder.HasOne(x => x.Oda)
                .WithMany(x => x.OdaMesajları)
                .HasForeignKey(x => x.OdaID)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.User)
                .WithMany(x => x.OdaMesajları)
                .HasForeignKey(x => x.UserID)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
