using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.Kullanici
{
    public class UpdateKullaniciDTO
    {
        
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public Guid? BolumID { get; set; }
        public string? PasswordHash { get; set; }
    }
}
