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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly protected DemoContext _entities;

        public UserRepository(DemoContext context) : base(context)
        {
            _entities = context;
        }
    }

}
