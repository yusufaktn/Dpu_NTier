using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.Fakulte
{
    public class FakulteDTO
    {
        public Guid ID { get; set; }
        public string FakülteAd { get; set; }
        public Guid UniversiteID { get; set; }
    }
}
