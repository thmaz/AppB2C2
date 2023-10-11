using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppB2C2.Models;

namespace AppB2C2.Pages.CollectionItems
{
    public class CreateModel : PageModel
    {
        private readonly AppB2C2.Models.AppDBContext _context;

        public CreateModel(AppB2C2.Models.AppDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CollectionId"] = new SelectList(_context.Collections, "CollectionId", "CollectionId");
            return Page();
        }

        [BindProperty]
        public CollectionItem CollectionItem { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.CollectionItems == null || CollectionItem == null)
            {
                return Page();
            }

            _context.CollectionItems.Add(CollectionItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
