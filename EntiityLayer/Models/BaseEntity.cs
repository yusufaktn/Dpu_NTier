﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntiityLayer.Models
{
    public  class BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public  DateTime? UpdatedDate { get; set; }
        public  bool IsActive { get; set; }


        public BaseEntity()
        {
            CreatedDate = DateTime.UtcNow;
            IsActive = true;
            


        }
    }
}
