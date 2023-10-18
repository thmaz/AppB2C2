using AppB2C2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AppB2C2.Controllers
{
    public class AdminTagsController : Controller
    {
        [HttpGet]
        public IActionResult Add() // Add is a controller for admin tags
        {
            return View();
        }
        
        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(AddTagRequest addTagRequest)
        {
            var tagName = addTagRequest.TagName;
            var displayName = addTagRequest.DisplayName;
            return View("Add");
        }
    }
}
