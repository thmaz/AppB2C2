using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppB2C2.Models;

namespace AppB2C2.Pages.Collections
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
        ViewData["CollectionId"] = new SelectList(_context.Users, "UserId", "UserName");
            return Page();
        }

        [BindProperty]
        public Collection Collection { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Collections == null || Collection == null)
            {
                return Page();
            }

            _context.Collections.Add(Collection);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
