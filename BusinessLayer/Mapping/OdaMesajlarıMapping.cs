using AutoMapper;
using BusinessLayer.DTOs.OdaMesajlar;
using EntiityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping
{
    public class OdaMesajlarıMapping:Profile
    {
        public OdaMesajlarıMapping()
        {
            CreateMap<CreateOdaMesajlarDTO, OdaMesajları>().ForMember(dest => dest.OdaMesajID, opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<UpdateOdaMesajlarDTO, OdaMesajları>();
            CreateMap<OdaMesajları, OdaMesajlarDTO>().ReverseMap();
            CreateMap<RemoveOdaMesajlarDTO, OdaMesajları>();
        }
    }
}
