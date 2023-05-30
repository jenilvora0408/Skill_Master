using CIPlatform.Auth;
using demo.Entities.Models;
using demo.Models.ViewModels;
using demo.Service.Interface;
using Entities.Auth;
using demo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace demo.Controllers
{
    public class UserController : Controller
    {
        
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly INotyfService _toastNotification;
        public UserController( IConfiguration configuration, IMapper mapper, IUserService userService, INotyfService toastNotification)
        {
          
            _configuration = configuration;
            _mapper = mapper;
            _userService = userService;
            _toastNotification = toastNotification;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                if (_userService.IsDataAvailable(user => user.Email == login.email))
                {
                    var user = _userService.FindDefaultEntity(user => user.Email == login.email);

                    var config = new MapperConfiguration(x => x.CreateMap<User, SessionDetailsViewModel>()
                    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")));

                    var mapper = new Mapper(config);
                    var users = mapper.Map<User, SessionDetailsViewModel>(user);
                    var jwtSetting = _userService.GetJwtSetting();
                    var token = JwtTokenHelper.GenerateToken(jwtSetting, users);

                    if (string.IsNullOrWhiteSpace(token))
                    {
                        ModelState.AddModelError("email", "Enter correct email");
                        return View("Login");
                    }

                    HttpContext.Session.SetString("Token", token);
                    HttpContext.Session.SetString("useremail", login.email);
                    HttpContext.Session.SetString("firstName", user.FirstName);
                    HttpContext.Session.SetString("lastname", user.LastName);
                    HttpContext.Session.SetString("userId", user.Id.ToString());

                    if (_userService.IsDataAvailable(user => user.Password == login.password && user.Email == login.email))
                    {
                        _toastNotification.Success("Login successfully");
                        return RedirectToAction("MissionSkill", "Skill");
                    }
                    else
                    {
                        ModelState.AddModelError("password", "Please enter correct Password");
                    }
                }
                else
                {
                    ModelState.AddModelError("email", "Please enter correct Email Address");
                }
            }
            return View(login);
        }

        public IActionResult logout()
        {
            HttpContext.Session.Remove("useremail");
            HttpContext.Session.Clear();
            _toastNotification.Success("Logged out successfully");
            return RedirectToAction("Login", "User");
        }
    }
}
