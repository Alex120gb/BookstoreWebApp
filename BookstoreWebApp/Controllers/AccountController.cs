using AutoMapper;
using BookstoreSdk;
using BookstoreSdk.Clients.Interface;
using BookstoreSdk.ViewModels;
using BookstoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserClient _userClient;
        private readonly IMapper _mapper;

        public AccountController(ILogger<AccountController> logger,
                              IUserClient userClient,
                              IMapper mapper)
        {
            _logger = logger;
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
            var result = await _userClient.Login(_mapper.Map<SdkLoginRequestModel>(request));

            var response = new Response<string>() {
                IsSuccessful = result.IsSuccessful,
                Value = result.Value,
                Message = result.Message
            };

            return Json(response);
        }

        [HttpPut]
        public async Task<JsonResult> Register([FromBody] RegisterUserModel request)
        {
            var result = await _userClient.RegisterUser(_mapper.Map<SdkRegisterUserModel>(request));

            var response = new Response<int>()
            {
                IsSuccessful = result.IsSuccessful,
                Value = result.Value,
                Message = result.Message
            };

            return Json(response);
        }
    }
}
