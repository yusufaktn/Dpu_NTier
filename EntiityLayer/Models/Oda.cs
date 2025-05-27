using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntiityLayer.Models
{
    public sealed class Oda:BaseEntity
    {
        public  Guid OdaID { get; set; }
        public string OdaAdı { get; set; }
        public Guid  UserID { get; set; }
        public AppUser User { get; set; }
        public string Aciklama { get; set; }
        public Guid BolumID { get; set; }
        public Bolum Bolum { get; set; }
        public ICollection<OdaMesajları> OdaMesajları { get; set; }



    }
}
