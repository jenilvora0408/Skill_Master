using demo.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Models.ViewModels
{
    public class SkillModel<T>
    {
        public List<T> skills { get; set; }

        public int PageCount { get; set; }

        public int PageSize { get; set; }

        public int CurrentPage { get; set; }
    }
}
