using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BookstoreWebApp.Models;
using BookstoreSdk.Clients.Interface;
using AutoMapper;
using BookstoreSdk.ViewModels;

namespace BookstoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookClient _bookClient;
        private readonly IMapper _mapper;

        public HomeController(IBookClient bookClient,
                              IMapper mapper)
        {
            _bookClient = bookClient;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddBookForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetBooks()
        {
            var token = HttpContext.Request.Headers["Authorization"];

            var result = await _bookClient.GetBooks(token);

            return Json(result);
        }

        [HttpPost]
        public async Task<JsonResult> AddBook([FromBody] BooksModel request)
        {
            var token = HttpContext.Request.Headers["Authorization"];

            var mappedData = _mapper.Map<SdkBooksModel>(request);

            var result = await _bookClient.AddBooks(mappedData, token);

            return Json(result);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateBook([FromBody] GetUpdateBooksViewModel request)
        {
            var token = HttpContext.Request.Headers["Authorization"];

            var mappedData = _mapper.Map<SdkGetUpdateBooksModel>(request);

            var result = await _bookClient.UpdateBook(mappedData, token);

            return Json(result);
        }

        [HttpPost]
        public async Task<JsonResult> DeleteBook([FromBody] int id)
        {
            var token = HttpContext.Request.Headers["Authorization"];

            var result = await _bookClient.DeleteBook(id, token);

            return Json(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}