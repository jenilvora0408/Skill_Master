using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using demo.Entities.Models;
using demo.Models.ViewModels;
using demo.Repository.Interface;
using demo.Repository.Repository;
using demo.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace demo.Service.Service
{
    public class SkillService : GenericService<Skill>, ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;   
        public SkillService(ISkillRepository skillRepository, IMapper mapper) : base(skillRepository)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
        }

        //private readonly IGenericRepository<Skill> _genericRepository;
        //public SkillService(IGenericRepository<Skill> genericRepository)
        //{
        //    _genericRepository = genericRepository;
        //}

      

       

      

    }
}
