using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Matei_Raul_Lab2.Data;
using Matei_Raul_Lab2.Models;
using Matei_Raul_Lab2.Models.ViewModels;

namespace Matei_Raul_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Matei_Raul_Lab2.Data.Matei_Raul_Lab2Context _context;

        public IndexModel(Matei_Raul_Lab2.Data.Matei_Raul_Lab2Context context)
        {
            _context = context;
        }
        public CategoryIndexData CategoryData {  get; set; }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync(int? id)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category.Include(c => c.BookCategories)
                 .ThenInclude(bc => bc.Book).ThenInclude(b => b.Authors)
                 .OrderBy(c => c.CategoryName).AsNoTracking().ToListAsync();


            if (id != null)
            {
                CategoryData.CategoryID = id.Value;
                var cat= CategoryData.Categories.Single(c=>c.ID==id.Value);
                CategoryData.Books = cat.BookCategories.Select(bc => bc.Book);
            }
        }

                
    }
}
