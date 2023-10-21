using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Negrea_Catalin_lab2.Data;
using Negrea_Catalin_lab2.Models;

namespace Negrea_Catalin_lab2.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Negrea_Catalin_lab2.Data.Negrea_Catalin_lab2Context _context;

        public CreateModel(Negrea_Catalin_lab2.Data.Negrea_Catalin_lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID","PublisherName");
            ViewData["AuthorID"] = new SelectList(_context.Set<Authors>(), "ID", "FirstName");
            ViewData["AuthorID"] = new SelectList(_context.Set<Authors>(), "ID", "LastName");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Book == null || Book == null)
            {
                return Page();
            }

          
            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
