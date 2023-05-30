using demo.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Entities.Data
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Skill> Skill { get; set; } = null!;

        public DbSet<UserSkill> UserSkills { get; set; } = null!;
    }
}
