using AutoMapper;
using BusinessLayer.DTOs.Mesaj;
using EntiityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping
{
    public class MesajlarMapping : Profile
    {

        public MesajlarMapping()
        {
            CreateMap<CreateMesajDTO, OdaMesajları>().ForMember(dest => dest.OdaMesajID, opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<UpdateMesajDTO, OdaMesajları>();
            CreateMap<OdaMesajları, MesajDTO>().ReverseMap();
            CreateMap<RemoveMesajDTO, OdaMesajları>();
        }
    }
}
