using demo.Entities.Models;
using demo.Service.Interface;
using Entities.Auth;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.Models.ViewModels;
using demo.Repository.Interface;

namespace demo.Service.Service
{
    public class UserService : GenericService<User> ,IUserService
    {
        private readonly IConfiguration _configuration;
       private readonly IUserRepository userRepository;
        public UserService(IConfiguration configuration, IUserRepository _userRepository) : base(_userRepository)
        {
            _configuration = configuration;
        }
        public JwtSetting GetJwtSetting()
        {
            return _configuration.GetSection(nameof(JwtSetting)).Get<JwtSetting>();
        }
    }
}
