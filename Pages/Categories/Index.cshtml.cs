using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Negrea_Catalin_lab2.Data;
using Negrea_Catalin_lab2.Models;
using Negrea_Catalin_lab2.Models.ViewModels;
using Negrea_Catalin_lab2.Pages.Categories;


namespace Negrea_Catalin_lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Negrea_Catalin_lab2.Data.Negrea_Catalin_lab2Context _context;

        public IndexModel(Negrea_Catalin_lab2.Data.Negrea_Catalin_lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;

        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }

        public async Task OnGetAsync(int? id, int? bookID)
        {
            CategoryData = new CategoryIndexData();

            CategoryData.Categories = await _context.Category
                .Include(i => i.Books).ThenInclude(c => c.Author)
                .OrderBy(i => i.CategoryName)
                .ToListAsync();
            if (id != null)
            {
                CategoryID = id.Value;
                CategoryData.Books = _context.Book
                    .Where(b => b.BookCategories.Any(bc => bc.CategoryID == id))
                    .Include(b => b.Author)
                    .ToList();
            }
        }
    }
}