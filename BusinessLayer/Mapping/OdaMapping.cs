using AutoMapper;
using BusinessLayer.DTOs.Odalar;
using BusinessLayer.DTOs.OdaMesajlar;
using EntiityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping
{
    public class OdaMapping:Profile
    {
        public OdaMapping()
        {
            CreateMap<Oda,OdaDTO>().ReverseMap();
            CreateMap<CreateOdaDTO,Oda>().ForMember(dest => dest.OdaID, opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<UpdateOdaDTO, Oda>();
            CreateMap<RemoveOdaDTO, Oda>();
        }


    }
}
