﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Negrea_Catalin_lab2.Data;
using Negrea_Catalin_lab2.Models;

namespace Negrea_Catalin_lab2.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly Negrea_Catalin_lab2.Data.Negrea_Catalin_lab2Context _context;

        public DetailsModel(Negrea_Catalin_lab2.Data.Negrea_Catalin_lab2Context context)
        {
            _context = context;
        }

      public Book Book { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book.Include(b => b.Author).Include(b => b.Publisher).FirstOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            else 
            {
                Book = book;
            }
            return Page();
        }
    }
}