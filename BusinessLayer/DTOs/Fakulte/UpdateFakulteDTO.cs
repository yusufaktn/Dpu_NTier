using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.Fakulte
{
    public class UpdateFakulteDTO
    {
        
        public string? FakülteAd { get; set; }
        public Guid? UniversiteID { get; set; }
    }
}
