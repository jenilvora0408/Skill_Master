using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using demo.Entities.Models;
using demo.Models.ViewModels;
using demo.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers
{
    [Authorize(Roles = "admin")]
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;
        private readonly INotyfService _toastNotification;
        private readonly IMapper _mapper;

        public SkillController(ISkillService skillService, INotyfService toastNotification, IMapper mapper)
        {
            _skillService = skillService;
            _toastNotification = toastNotification;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MissionSkill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSkill(SkillCrud skillCrud)
        {
            bool success = _skillService.Any(x => x.SkillName == skillCrud.SkillName);
            if (ModelState.IsValid)
            {
                var skill = _mapper.Map<SkillCrud, Skill>(skillCrud);
                if (!_skillService.Any(skill.Id == 0 ? (x => x.SkillName == skillCrud.SkillName) : (x => x.Id != skill.Id && x.SkillName == skillCrud.SkillName)))
                {
                    if (skill.Id == 0 || skill.Id == null)
                        _skillService.Add(skill);
                    else
                        _skillService.Edit(skill);
                }


                if ((skillCrud.Id == null || skillCrud.Id == 0) && !success)
                {
                    _toastNotification.Success("Skill Added successfully");
                }
                else if (success)
                {
                    _toastNotification.Warning("Skill already exists");
                }
                else
                {
                    _toastNotification.Success("Skill Edited successfully");
                }
                return RedirectToAction("MissionSkill");
            }
            else
            {
                ModelState.AddModelError("SkillName", "Skill Name already exists.");
            }
            return View("MissionSkill", skillCrud);
        }

        public IActionResult SkillTable(string search, int pageNumber, int sorting)
        {
            //x => pageUtilities.searchSkill != null ? (x.SkillName.ToLower().Contains(pageUtilities.searchSkill.ToLower()) && x.DeletedDate == null) : (x.DeletedDate == null),

            var skillList = _skillService.GetSkillList(search, pageNumber, search,
                skill => search != null ? (skill.SkillName.ToLower().Contains(search.ToLower())) :
                (skill.Deleted_at == null),
                q => sorting == 0 ? q.OrderBy(x => x.SkillName) : q.OrderByDescending(x => x.SkillName));
            return PartialView("_SkillTable", skillList);
        }

        public IActionResult EditSkill(long SkillId)
        {
            var skillData = _skillService.GetSkillData(x => x.Id == SkillId);
            return View(skillData);
        }

        public IActionResult DeleteSkill(long skillName)
        {
            _skillService.DeleteSkillData(x => x.Id == skillName);
            _toastNotification.Success("Skill Deleted successfully");
            return Ok();
        }
    }
}
