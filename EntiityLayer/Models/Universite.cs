using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntiityLayer.Models
{
    public sealed class Universite:BaseEntity
    {
        public Guid ID{ get; set; }
        public string UniversiteAd { get; set; }
        public ICollection<Fakulte> Fakulteler { get; set; } 
    }
}
