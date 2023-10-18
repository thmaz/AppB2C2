using AppB2C2.Data;
using AppB2C2.Models.Domain;
using AppB2C2.Models.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace AppB2C2.Controllers
{
    public class MusicItemsController : Controller
    {
        private readonly DjDbContext djDbContext;

        public MusicItemsController(DjDbContext djDbContext)
        {
            this.djDbContext = djDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddMusicItemRequest addMusicItemRequest) 
        {
            var musicItem = new MusicItem
            {
                ItemTitle = addMusicItemRequest.ItemTitle,
                ItemDescription = addMusicItemRequest.ItemDescription,
                ImageUrl = addMusicItemRequest.ImageUrl,
                Artist = addMusicItemRequest.Artist,
                ItemContent = addMusicItemRequest.ItemContent,
                UrlHandle = addMusicItemRequest.UrlHandle,
                Visible = addMusicItemRequest.Visible
            };

            djDbContext.MusicItems.Add(musicItem);
            djDbContext.SaveChanges();

            return View("Add");
        }

        [HttpGet]
        public IActionResult Details(Guid itemId) 
        {
            var musicItem = djDbContext.MusicItems.FirstOrDefault(m => m.Id == itemId);

            if (musicItem == null)
            {
                Console.WriteLine($"Music item with ID '{itemId}' not found.");
                return NotFound();
            }

            var musicItemDetailsViewModel = new MusicItemDetailsViewModel
            {

            };
            return View(musicItem);
        }
    }
}
