using AutoMapper;
using BusinessLayer.DTOs.Fakulte;
using EntiityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping
{
    public class FakulteMapping:Profile
    {
        public FakulteMapping()
        {
            CreateMap<CreateFakulteDTO, Fakulte>().ForMember(Fakulte => Fakulte.ID, opt => opt.MapFrom(s => Guid.NewGuid()));
            CreateMap<UpdateFakulteDTO, Fakulte>();
            CreateMap<Fakulte, FakulteDTO>().ReverseMap();
            CreateMap<RemoveFakulteDTO, Fakulte>();




        }
    }
}
