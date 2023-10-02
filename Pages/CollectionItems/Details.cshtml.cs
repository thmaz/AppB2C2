using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppB2C2.Models;

namespace AppB2C2.Pages.CollectionItems
{
    public class DetailsModel : PageModel
    {
        private readonly AppB2C2.Models.AppDBContext _context;

        public DetailsModel(AppB2C2.Models.AppDBContext context)
        {
            _context = context;
        }

      public CollectionItem CollectionItem { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CollectionItems == null)
            {
                return NotFound();
            }

            var collectionitem = await _context.CollectionItems.FirstOrDefaultAsync(m => m.ItemId == id);
            if (collectionitem == null)
            {
                return NotFound();
            }
            else 
            {
                CollectionItem = collectionitem;
            }
            return Page();
        }
    }
}
