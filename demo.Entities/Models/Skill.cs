using demo.Entities.DataEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Entities.Models
{
    public class Skill : AuditableEntity<long>
    {
        [Required]
        public string SkillName { get; set; } = null!;

        [Required]
        public bool Status { get; set; } = false;
    }
}
