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
    internal class UniversiteConfigration : IEntityTypeConfiguration<Universite>
    {
        public void Configure(EntityTypeBuilder<Universite> builder)
        {
            builder.HasKey(u => u.ID);
            builder.Property(u=>u.UniversiteAd).HasColumnType("varchar(80)").IsRequired();


            builder.HasMany(u=>u.Fakulteler)// Bir üniversite kaydının birden fazla fakülte kaydı olabilir
                .WithOne(f => f.Universite)// Bir fakülte kaydının bir üniversite kaydı vardır. Birden fazla üniversite ile ilişkilendirilemez
                .HasForeignKey(f => f.UniversiteID)
                .OnDelete(DeleteBehavior.Cascade); 

        }
    }
}
