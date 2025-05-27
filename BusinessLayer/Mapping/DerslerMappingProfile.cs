using AutoMapper;
using BusinessLayer.DTOs.Dersler;
using EntiityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping
{
    public class DerslerMappingProfile:Profile
    {
        public DerslerMappingProfile()
        {
            CreateMap<CreateDersDTO, Dersler>().ForMember(dest => dest.DersID, opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<UpdateDersDTO, Dersler>();
            CreateMap<Dersler, DersDTO>().ReverseMap();
            CreateMap<RemoveDersDTO,Dersler>();
                


        }
    }
}
