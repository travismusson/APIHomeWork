using APIHomeWork.Models;
using APIHomeWork.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIHomeWork.Controllers
{
    public class NewsController : Controller
    {
        private readonly Services.NewsApiService _newsApiService;

        public NewsController(NewsApiService newsApiService)
        {
            _newsApiService = newsApiService;
        }
        public async Task<IActionResult> News()
        {
            
            var newsResponse = await _newsApiService.GetNewsAsync();
            Console.WriteLine($"Articles count: {newsResponse?.Articles?.Count}");      //debug
            var articles = newsResponse?.Articles ?? new List<Article>();
            return View(articles);
        }
    }
}
