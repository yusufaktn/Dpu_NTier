using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.Bolum
{
    public class CreateBolumDTO
    {
       
        public string BolumAd { get; set; }
        public Guid FakulteID { get; set; }
    }
}
