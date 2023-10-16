using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppB2C2.Models;

namespace AppB2C2.Pages.Collections
{
    public class EditModel : PageModel
    {
        private readonly AppB2C2.Models.AppDBContext _context;

        public EditModel(AppB2C2.Models.AppDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Collection Collection { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Collections == null)
            {
                return NotFound();
            }

            var collection =  await _context.Collections.FirstOrDefaultAsync(m => m.CollectionId == id);
            if (collection == null)
            {
                return NotFound();
            }
            Collection = collection;
           ViewData["CollectionId"] = new SelectList(_context.DjUsers, "UserId", "UserId");
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

            _context.Attach(Collection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollectionExists(Collection.CollectionId))
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

        private bool CollectionExists(int id)
        {
          return (_context.Collections?.Any(e => e.CollectionId == id)).GetValueOrDefault();
        }
    }
}
