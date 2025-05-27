using AutoMapper;
using BusinessLayer.DTOs.Kullanici;
using EntiityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping
{
    public class KullaniciMapping:Profile
    {
        public KullaniciMapping()
        {
            CreateMap<CreateKullaniciDTO, AppUser>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<UpdateKullaniciDTO, AppUser>();
            CreateMap<AppUser, KullaniciDTO>().ReverseMap();
            CreateMap<RemoveKullaniciDTO,AppUser>();
            CreateMap<KullaniciLoginDTO, AppUser>().ReverseMap();
        }
    }
}
