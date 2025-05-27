using BusinessLayer.DTOs.Dersler;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
    internal class UpdateDersValidator:AbstractValidator<UpdateDersDTO>
    {
        public UpdateDersValidator()
        {
            
        }
    }
}
