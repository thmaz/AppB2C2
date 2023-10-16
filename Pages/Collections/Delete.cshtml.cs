using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppB2C2.Models;

namespace AppB2C2.Pages.Collections
{
    public class DeleteModel : PageModel
    {
        private readonly AppDBContext _context;

        public DeleteModel(AppDBContext context)
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

            var collection = await _context.Collections.FirstOrDefaultAsync(m => m.CollectionId == id);

            if (collection == null)
            {
                return NotFound();
            }
            else 
            {
                Collection = collection;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Collections == null)
            {
                return NotFound();
            }
            var collection = await _context.Collections.FindAsync(id);

            if (collection != null)
            {
                Collection = collection;
                _context.Collections.Remove(Collection);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
