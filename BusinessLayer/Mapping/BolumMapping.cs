using AutoMapper;
using BusinessLayer.DTOs.Bolum;
using EntiityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping
{
    public class BolumMapping: Profile
    {
        public BolumMapping()
        {
            CreateMap<CreateBolumDTO, Bolum>().ForMember(Bolum => Bolum.ID, opt => opt.MapFrom(s => Guid.NewGuid()));
            CreateMap<UpdateBolumDTO, Bolum>();
            CreateMap<Bolum, BolumDTO>().ReverseMap();
            CreateMap<RemoveBolumDTO, Bolum>();
        }
    }
    
}
