using Microsoft.AspNetCore.Mvc;
using AppB2C2.Models;
using System.Diagnostics;
using AppB2C2.Models.Domain;

namespace AppB2C2.Controllers
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
            var musicItems = GetMusicItems();
            return View("Index", musicItems);
        }

        private List<MusicItem> GetMusicItems()
        {
            var musicItems = new List<MusicItem>
            {
                new MusicItem { ItemTitle = "Bleach", ItemDescription = "Used condition by Nirvana", ImageUrl = "/uploads/bleach.png" },
                new MusicItem { ItemTitle = "Green mind", ItemDescription = "LP in new condition", ImageUrl = "/uploads/greenmind.png" },
                new MusicItem { ItemTitle = "Licensed to ill", ItemDescription = "Mint condition", ImageUrl = "/uploads/licensedtoill.png" },
            };

            return musicItems;
        }

        public IActionResult Privacy()
        {
            return View("Privacy");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
