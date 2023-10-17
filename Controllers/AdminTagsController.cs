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
        public IActionResult SubmitTag()
        {
            return View("Add");
        }
    }
}
