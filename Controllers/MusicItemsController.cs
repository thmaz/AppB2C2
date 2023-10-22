using AppB2C2.Data;
using AppB2C2.Migrations;
using AppB2C2.Models.Domain;
using AppB2C2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Linq;

namespace AppB2C2.Controllers
{
    public class MusicItemsController : Controller
    {
        private readonly DjDbContext djDbContext;
        private readonly IHostEnvironment hostEnvironment;

        // GetTagPrice makes items of type CD 70% of TagValue and so forth ...
        private float GetTagPriceFactor(MusicItemType itemType)
        {
            switch (itemType)
            {
                case MusicItemType.CD:
                    return 0.7f;
                case MusicItemType.Cassette:
                    return 0.5f;
                case MusicItemType.LP:
                    return 1.2f;
                default:
                    return 1.0f;
            }
        }

        private float CalculatePriceDifferencePercentage(MusicItem musicItem, float tagPriceFactor)
        {
            float purchaseValue = musicItem.ItemValue;
            float totalTagPrice = musicItem.ItemTags?.Sum(tag => tag.TagPrice * tagPriceFactor) ?? 0;

            float difference = purchaseValue - totalTagPrice;
            float percentageDifference = (purchaseValue/totalTagPrice) * 100;

            return percentageDifference;
        }

        public MusicItemsController(DjDbContext djDbContext, IHostEnvironment hostEnvironment)
        {
            this.djDbContext = djDbContext;
            this.hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult AddItem()
        {
            ViewBag.Tags = djDbContext.ItemTags.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddItem(AddMusicItemRequest addMusicItemRequest, List<Guid> tagIds, MusicItemType itemType)
        {
            var musicItem = new MusicItem
            {
                ItemTitle = addMusicItemRequest.ItemTitle,
                ItemDescription = addMusicItemRequest.ItemDescription,
                Artist = addMusicItemRequest.Artist,
                ItemContent = addMusicItemRequest.ItemContent,
                DateAdded = addMusicItemRequest.DateAdded,
                ItemValue = addMusicItemRequest.ItemValue,
                ItemType = addMusicItemRequest.ItemType
            };

            var tagPriceFactor = GetTagPriceFactor(itemType);
            musicItem.ItemTags = djDbContext.ItemTags.Where(tag => tagIds.Contains(tag.Id)).ToList();

            if (addMusicItemRequest.ImageFile != null && addMusicItemRequest.ImageFile.Length > 0)
            {
                string uploadsFolder = Path.Combine(hostEnvironment.ContentRootPath, "wwwroot", "uploads");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + addMusicItemRequest.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    addMusicItemRequest.ImageFile.CopyTo(stream);
                }

                musicItem.ImageUrl = "/uploads/" + uniqueFileName;
            }

            musicItem.ItemTags = djDbContext.ItemTags.Where(tag => tagIds.Contains(tag.Id)).ToList();

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

            var musicItem = djDbContext.MusicItems
                .Include(item => item.ItemTags)
                .FirstOrDefault(item => item.Id == itemId);

            if (musicItem == null)
            {
                return NotFound();
            }

            var tagPriceFactor = GetTagPriceFactor(musicItem.ItemType); // For displaying TagPrice in details

            var musicItemDetailsViewModel = new MusicItemDetailsViewModel
            {
                ItemTitle = musicItem.ItemTitle,
                ItemDescription = musicItem.ItemDescription,
                ImageUrl = musicItem.ImageUrl,
                Artist = musicItem.Artist,
                ItemContent = musicItem.ItemContent,
                DateAdded = musicItem.DateAdded,
                ItemValue = musicItem.ItemValue,
                Tags = musicItem.ItemTags.Select(tag => tag.TagName).ToList(),

                ItemType = musicItem.ItemType,
                PriceDifferencePercentage = CalculatePriceDifferencePercentage(musicItem, tagPriceFactor),
                TagPrice = musicItem.ItemTags?.FirstOrDefault()?.TagPrice ?? 0
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

        [HttpGet]
        public IActionResult Edit(Guid itemId, List<Guid> tagIds)
        {
            var musicItem = djDbContext.MusicItems
                .Include(item => item.ItemTags)
                .FirstOrDefault(item => item.Id == itemId);

            if (musicItem == null)
            {
                return NotFound();
            }

            /*ViewBag.Tags = djDbContext.ItemTags
                .Select(tag => new SelectListItem { Value = tag.Id.ToString(), Text = tag.TagName })
                .ToList(); */

            var editViewModel = new EditMusicViewModel
            {
                ItemTitle = musicItem.ItemTitle,
                ItemDescription = musicItem.ItemDescription,
                Artist = musicItem.Artist,
                ItemContent = musicItem.ItemContent,
                DateAdded = musicItem.DateAdded,
                ItemValue = musicItem.ItemValue,
                // Itemtype = itemtype
            };

            return View("EditItem", editViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditMusicViewModel editViewModel)
        {
            /* if (ModelState.IsValid)
             { */
            var musicItem = djDbContext.MusicItems
                .Include(item => item.ItemTags)
                .FirstOrDefault(item => item.Id == editViewModel.Id);

            if (musicItem == null)
            {
                return NotFound();
            }



            musicItem.ItemTitle = editViewModel.ItemTitle;
            musicItem.ItemDescription = editViewModel.ItemDescription;
            musicItem.Artist = editViewModel.Artist;
            musicItem.DateAdded = editViewModel.DateAdded;
            musicItem.ItemValue = editViewModel.ItemValue;

            // musicItem.ItemTags.Clear();

            /*foreach (var tagId in editViewModel.TagIds) 
            {
                var tag = new ItemTag { Id = Guid.Parse(tagId) };
                musicItem.ItemTags.Add(tag);
            } */

            djDbContext.SaveChanges();

            //return RedirectToAction("Details", new { itemId = musicItem.Id });
            //}

            /* ViewBag.Tags = djDbContext.ItemTags
                 .Select(tag => new SelectListItem { Value = tag.Id.ToString(), Text = tag.TagName })
                 .ToList(); */

            return RedirectToAction("AllItems");
        }

        public IActionResult Search(string searchTerm)
        {
            var searchResults = djDbContext.MusicItems
                .Where(item => item.ItemTags.Any(tag => tag.TagName.Contains(searchTerm)))
                .ToList();

            return View("SearchResults", searchResults ?? new List<MusicItem>());
        }
    }
}
