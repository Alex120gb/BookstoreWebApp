using AutoMapper;
using BookstoreSdk.Clients.Interface;
using BookstoreSdk.ViewModels;
using BookstoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserClient _userClient;
        private readonly IMapper _mapper;

        public AccountController(IUserClient userClient,
                                 IMapper mapper)
        {
            _userClient = userClient;
            _mapper = mapper;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegisterForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Login([FromBody] LoginRequestModel request)
        {
            var mappedData = _mapper.Map<SdkLoginRequestModel>(request);

            var result = await _userClient.Login(mappedData);

            return Json(result);
        }

        [HttpPut]
        public async Task<JsonResult> Register([FromBody] RegisterUserModel request)
        {
            var mappedData = _mapper.Map<SdkRegisterUserModel>(request);

            var result = await _userClient.RegisterUser(mappedData);

            return Json(result);
        }
    }
}