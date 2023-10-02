using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppB2C2.Models;

namespace AppB2C2.Pages.CollectionItems
{
    public class EditModel : PageModel
    {
        private readonly AppB2C2.Models.AppDBContext _context;

        public EditModel(AppB2C2.Models.AppDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CollectionItem CollectionItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CollectionItems == null)
            {
                return NotFound();
            }

            var collectionitem =  await _context.CollectionItems.FirstOrDefaultAsync(m => m.ItemId == id);
            if (collectionitem == null)
            {
                return NotFound();
            }
            CollectionItem = collectionitem;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CollectionItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollectionItemExists(CollectionItem.ItemId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CollectionItemExists(int id)
        {
          return (_context.CollectionItems?.Any(e => e.ItemId == id)).GetValueOrDefault();
        }
    }
}
