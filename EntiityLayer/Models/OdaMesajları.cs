using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntiityLayer.Models
{
    public sealed class OdaMesajları:BaseEntity
    {
        public Guid OdaMesajID { get; set; }
        public string Mesaj { get; set; }
        public DateTime MesajTarihi { get; set; }
        public string DosyaYolu { get; set; }
        public Guid OdaID { get; set; }
        public Guid UserID { get; set; }
        public Oda Oda { get; set; }
        public AppUser User { get; set; }
       



    }
}
