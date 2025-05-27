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
    internal class OgretmenDerslerConfigration : IEntityTypeConfiguration<OgretmenDersler>
    {
        public void Configure(EntityTypeBuilder<OgretmenDersler> builder)
        {
            builder.HasKey(x => new {x.OgretmenID,x.DersID});
            builder.ToTable("OgretmenDersler");
            builder.Property(x=>x.OgretmenID).IsRequired();
            builder.Property(x => x.DersID).IsRequired();
            builder.Property(x => x.DonemYil).IsRequired().HasColumnType("varchar(50)");
            builder.Property(x => x.AktifMi).IsRequired().HasDefaultValue(true);


            builder.HasOne(x => x.Ogretmen)//Bir öğretmenin birden fazla dersi olabilir
                .WithMany(x => x.OgretmenDersleri)//Karşılık olarak bir dersin birden fazla öğretmeni olabilir
                .HasForeignKey(x => x.OgretmenID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Ders)//Bir dersin birden fazla öğretmeni olabilir
                .WithMany(x=>x.OgretmenDersleriAtanan)//Karşılık olarak bir öğretmenin birden fazla dersi olabilir
                .HasForeignKey(x => x.DersID)
                .OnDelete(DeleteBehavior.Cascade);


            // Burada bir dersi birden fazla öğretmen alabilir olarak belirledik fakat bir öğretmenin bir dersi birden fazla alması mümkün değil.
            // Ama farklı öğretmen sonradan değişebileceği için bunu birden fazla alabilir olarak belirledik.
            //Bunun kontrolünü BLL katmanında yapacağız.

        }
    }
}
