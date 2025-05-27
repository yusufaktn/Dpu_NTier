using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntiityLayer.Models
{
    public sealed class AppUser:IdentityUser<Guid>
    {
        public Guid BolumID { get; set; }
        public Bolum Bolum { get; set; }

        public ICollection<Oda> Odalar { get; set; }
        public ICollection<OdaMesajları> OdaMesajları { get; set; }

    }
}
