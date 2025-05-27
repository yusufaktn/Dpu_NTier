using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntiityLayer.Models
{
    public sealed class Ogretmen: BaseEntity
    {
        public Guid ID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Eposta { get; set; }
        public string Telefon { get; set; }
        public ICollection<DersNotu> DerslerNotlari { get; set; } // Navigation property
        public ICollection<OgretmenDersler> OgretmenDersleri { get; set; } // Navigation property
    }
}
