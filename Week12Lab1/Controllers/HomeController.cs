using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Week12Lab1.Models;
using System.Net.Http;

namespace Week12Lab1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> testapicall()
        {
            string domain = "https://deckofcardsapi.com/";
            string path = $"/api/deck/new/shuffle/?deck_count=1";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(domain);
            var connection = await client.GetAsync(path);
            string result = await connection.Content.ReadAsStringAsync();

            return Content(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
