using demo.Entities.Data;
using demo.Entities.Models;
using demo.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Repository.Repository
{
    public class SkillRepository: GenericRepository<Skill>,ISkillRepository
    {
        private readonly protected DemoContext _entities;

        public SkillRepository(DemoContext context) : base(context)
        {
            _entities = context;
        }
    }
}
