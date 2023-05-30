using AutoMapper;
using demo.Entities.Models;
using demo.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Models.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //    CreateMap<T, TDto>().ReverseMap();
            //    CreateMap<T, TDto>();
            CreateMap<SkillCrud, Skill>();
            CreateMap<User, LoginModel>().ReverseMap();
            //CreateMap<Skill, SkillViewModel>().ReverseMap();
            CreateMap<User, SessionDetailsViewModel>()
           .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")).ReverseMap();


        }
    }
}
