using AppB2C2.Data;
using AppB2C2.Models.Domain;
using AppB2C2.Models.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        public IActionResult AddItem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddItem(AddMusicItemRequest addMusicItemRequest) 
        {
            var musicItem = new MusicItem
            {
                ItemTitle = addMusicItemRequest.ItemTitle,
                ItemDescription = addMusicItemRequest.ItemDescription,
                ImageUrl = addMusicItemRequest.ImageUrl,
                Artist = addMusicItemRequest.Artist,
                ItemContent = addMusicItemRequest.ItemContent,
                UrlHandle = addMusicItemRequest.UrlHandle,
                Visible = addMusicItemRequest.Visible,
                DateAdded = addMusicItemRequest.DateAdded,
                ItemValue = addMusicItemRequest.ItemValue
            };

            djDbContext.MusicItems.Add(musicItem);
            djDbContext.SaveChanges();

            return RedirectToAction("AllItems", musicItem);
        }

        [HttpGet]
        public IActionResult Details(Guid itemId) 
        {
            if (itemId == Guid.Empty)
            {
                return NotFound();
            }

            var musicItem = djDbContext.MusicItems.Find(itemId);

            if (musicItem == null) 
            {
                return NotFound();
            }

            var musicItemDetailsViewModel = new MusicItemDetailsViewModel
            {
                ItemTitle = musicItem.ItemTitle,
                ItemDescription = musicItem.ItemDescription,
                ImageUrl = musicItem.ImageUrl,
                Artist = musicItem.Artist,
                ItemContent = musicItem.ItemContent,
                UrlHandle = musicItem.UrlHandle,
                Visible = musicItem.Visible,
                DateAdded = musicItem.DateAdded,
                ItemValue = musicItem.ItemValue
            };

            return View("DetailItem", musicItemDetailsViewModel);
        }

        [HttpGet]
        public IActionResult AllItems()
        {
            var musicItems = djDbContext.MusicItems.ToList();
            return View("AllItems", musicItems);
        }


        [HttpGet]
        public IActionResult Delete(Guid itemId)
        {
            if (itemId == Guid.Empty) 
            {
                return NotFound();
            }

            MusicItem musicItem = djDbContext.MusicItems.Find(itemId);

            if (musicItem == null)
            {
                return NotFound();
            }

            return View("DeleteItem", musicItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid itemId)
        {
            MusicItem musicItem = djDbContext.MusicItems.Find(itemId);
            if (musicItem == null)
            {
                return NotFound();
            }

            djDbContext.MusicItems.Remove(musicItem);
            djDbContext.SaveChanges();
            return RedirectToAction("AllItems");
        }
    }

}
