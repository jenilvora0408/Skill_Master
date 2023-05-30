using demo.Entities.Models;
using Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Service.Interface
{
    public interface IUserService : IGenericService<User>
    {
        public JwtSetting GetJwtSetting();
    }
}
