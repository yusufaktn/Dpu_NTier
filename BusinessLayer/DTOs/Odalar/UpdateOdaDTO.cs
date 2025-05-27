using EntiityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.Odalar
{
    public class UpdateOdaDTO
    {

        public string? OdaAdı { get; set; }
        public Guid? UserID { get; set; }
        public string? Aciklama { get; set; }
        public Guid? BolumID { get; set; }
    }
}
