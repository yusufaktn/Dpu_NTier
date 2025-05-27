using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntiityLayer.Models
{
    public sealed class Bolum : BaseEntity
    {
        public Guid ID { get; set; }
        public string BolumAd { get; set; }
        public Guid FakulteID { get; set; } 
        public Fakulte Fakulte { get; set; } 
        public ICollection<Dersler> Dersler { get; set; }
        public ICollection<Oda> Odalar { get; set; }
        public ICollection<AppUser> AppUsers { get; set; }
    }
}
