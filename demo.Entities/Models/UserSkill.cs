using demo.Entities.DataEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Entities.Models
{
    public class UserSkill : AuditableEntity<long>
    {
        public long UserId { get; set; }

        public long SkillId { get; set; }

        [ForeignKey("SkillId")]
        public Skill Skill { get; set; } = null!;

        [ForeignKey("UserId")]
        public User User { get; set; } = null!;
    }
}
