using AppB2C2.Data;
using AppB2C2.Migrations;
using AppB2C2.Models.Domain;
using AppB2C2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AppB2C2.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly DjDbContext djDbContext;

        public AdminTagsController(DjDbContext djDbContext) 
        {
            this.djDbContext = djDbContext;
        }   

        [HttpGet]
        public IActionResult Add() // Add is a controller for admin tags
        {
            return View();
        }
        
        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(AddTagRequest addTagRequest)
        { 
                var tag = new ItemTag
                {
                    TagName = addTagRequest.TagName,
                    DisplayName = addTagRequest.DisplayName,
                    TagPrice = addTagRequest.TagPrice
                };

            djDbContext.ItemTags.Add(tag);
            djDbContext.SaveChanges();

            return View("Add");
        }

        [HttpGet]
        public IActionResult Details(string tagName)
        {   
            var tag = djDbContext.ItemTags.FirstOrDefault(t => t.TagName == tagName);

            if (tag == null)
            {
                Console.WriteLine($"Tag with tagName '{tagName}' not found.");
                return NotFound();
            }

            var tagDetailsViewModel = new TagDetailsViewModel
            {
                TagName = tagName,
                DetailName = tag.DisplayName,
                TagPrice = tag.TagPrice
            };

            return View("Details", tagDetailsViewModel);
        }

        [HttpGet]
        public IActionResult AllTags()
        {
            var allTags = djDbContext.ItemTags.ToList();
            return View("AllTags", allTags);
        }

        [HttpGet]
        public IActionResult Delete(string tagName)
        {
            var tag = djDbContext.ItemTags.FirstOrDefault(t => t.TagName == tagName);

            if (tag == null)
            {
                Console.WriteLine($"Tag with tagName '{tagName}' not found.");
                return NotFound();
            }

            return View("Delete", tag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(string tagName)
        {
            var tag = djDbContext.ItemTags.FirstOrDefault(t => t.TagName == tagName);

            if (tag == null)
            {
                Console.WriteLine($"Tag with tagName '{tagName}' not found.");
                return NotFound();
            }

            djDbContext.ItemTags.Remove(tag);
            djDbContext.SaveChanges();

            return RedirectToAction("AllTags");
        }

    }
}


