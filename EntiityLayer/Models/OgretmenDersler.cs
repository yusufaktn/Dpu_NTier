using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntiityLayer.Models
{
    public sealed class OgretmenDersler:BaseEntity
    {
        
        public Guid OgretmenID { get; set; } 
        public Ogretmen Ogretmen { get; set; }

        public Guid DersID { get; set; } 
        public Dersler Ders { get; set; }

        public string DonemYil { get; set; } // Örn: "2024-2025 Güz", "2024-2025 Bahar" vb.
        public bool AktifMi { get; set; } // Bu atama şu an geçerli mi? (O dönem için dersi veren aktif öğretmen mi?)
    }
}
