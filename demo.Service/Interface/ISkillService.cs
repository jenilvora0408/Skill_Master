using demo.Entities.Models;
using demo.Models.ViewModels;
using demo.Repository.Interface;
using demo.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Service.Interface
{
    public interface ISkillService: IGenericService<Skill>
    {
        //public void AddSkills(Skill skillCrud);

        //public bool FindSkill(string skillName);


        //public SkillCrud GetSkillData(long id);

        //public void DeleteSkillData(string skillName);
    }
}
