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
    public class DetailsModel : PageModel
    {
        private readonly AppDBContext _context;

        public DetailsModel(AppDBContext context)
        {
            _context = context;
        }

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
    }
}
