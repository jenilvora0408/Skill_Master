using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Models.ViewModels
{
    public class SkillCrud
    {
        public long? Id { get; set; }

        [Required(ErrorMessage = "Skill Name is Required.")]
        public string SkillName { get; set; } = null!;

        [Required(ErrorMessage = "Please select Status.")]
        public bool Status { get; set; }
    }
}
