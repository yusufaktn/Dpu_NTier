using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.Dersler
{
    public class CreateDersDTO
    {
        public string DersAd { get; set; }
        public string Donem { get; set; }
        public Guid BolumID { get; set; }
    }
}
