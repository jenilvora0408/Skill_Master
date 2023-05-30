using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Entities.DataEntities
{
    public interface IAuditableEntity
    {
        DateTime Created_at { get; set; }

        DateTime? Updated_at { get; set; }

        DateTime? Deleted_at { get; set; }
    }
}
