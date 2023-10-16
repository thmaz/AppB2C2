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
    public class IndexModel : PageModel
    {
        private readonly AppDBContext _context;

        public IndexModel(AppDBContext context)
        {
            _context = context;
        }

        public IList<Collection> Collection { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Collections != null)
            {
                Collection = await _context.Collections
                .Include(c => c.DjUser).ToListAsync();
            }
        }
    }
}
