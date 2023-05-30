using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Entities.DataEntities
{
    public abstract class AuditableEntity<T> : Entity<T>, IAuditableEntity
    {
        [ScaffoldColumn(false)]
        public DateTime Created_at { get; set; } = DateTime.Now;

        [ScaffoldColumn(false)]
        public DateTime? Updated_at { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? Deleted_at { get; set; }

    }
}
