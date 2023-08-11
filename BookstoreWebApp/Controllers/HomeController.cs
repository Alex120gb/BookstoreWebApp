using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BookstoreWebApp.Models;
using BookstoreSdk.Clients.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Headers;
using System.Net.Http;
using BookstoreSdk.ViewModels;

namespace BookstoreWebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBookClient _bookClient;
    private readonly IMapper _mapper;

    public HomeController(ILogger<HomeController> logger, 
                          IBookClient bookClient,
                          IMapper mapper)
    {
        _logger = logger;
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
        string token = HttpContext.Request.Headers["Authorization"];

        var result = await _bookClient.GetBooks(token);

        var mappedData = _mapper.Map<List<GetUpdateBooksViewModel>>(result);

        return Json(mappedData);
    }

    [HttpPost]
    public async Task<JsonResult> AddBook([FromBody] BooksModel request)
    {
        string token = HttpContext.Request.Headers["Authorization"];

        var mappedData = _mapper.Map<SdkBooksModel>(request);

        var result = await _bookClient.AddBooks(mappedData, token);

        return Json(result);
    }

    [HttpPost]
    public async Task<JsonResult> UpdateBook([FromBody] GetUpdateBooksViewModel request)
    {
        string token = HttpContext.Request.Headers["Authorization"];

        var mappedData = _mapper.Map<SdkGetUpdateBooksModel>(request);

        var result = await _bookClient.UpdateBook(mappedData, token);

        return Json(result);
    }

    [HttpPost]
    public async Task<JsonResult> DeleteBook([FromBody] int id)
    {
        string token = HttpContext.Request.Headers["Authorization"];

        var result = await _bookClient.DeleteBook(id, token);

        return Json(result);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
