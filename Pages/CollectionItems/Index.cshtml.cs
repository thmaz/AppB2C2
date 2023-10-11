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
    public class IndexModel : PageModel
    {
        private readonly AppB2C2.Models.AppDBContext _context;

        public IndexModel(AppB2C2.Models.AppDBContext context)
        {
            _context = context;
        }

        public IList<CollectionItem> CollectionItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CollectionItems != null)
            {
                CollectionItem = await _context.CollectionItems
                .Include(c => c.Collection).ToListAsync();
            }
        }
    }
}
