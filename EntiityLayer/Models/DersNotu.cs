using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntiityLayer.Models
{
    public sealed class DersNotu:BaseEntity
    {
        public Guid DersNotuID { get; set; }
        public Guid DersID { get; set; }
        public Dersler Ders { get; set; }
        public Guid  OgretmenID { get; set; }
        public Ogretmen Ogretmen { get; set; }
        public string NotBaslıgı { get; set; }
        public string DosyaYolu { get; set; }
        public DateTime  YuklemeTarih { get; set; }

        public DersNotu()
        {
            YuklemeTarih = DateTime.Now;
        }
    }
}
