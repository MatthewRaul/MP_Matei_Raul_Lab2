using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab2.Models;
using Matei_Raul_Lab2.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Matei_Raul_Lab2.Models;

namespace Matei_Raul_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Matei_Raul_Lab2.Data.Matei_Raul_Lab2Context _context;

        public IndexModel(Matei_Raul_Lab2.Data.Matei_Raul_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public SelectList? AuthorsList { get;set; }
        public int? SelectedAuthorsID { get; set; }
        public async Task OnGetAsync()

        {
            Book = await _context.Book.Include(b => b.Publisher).Include(b => b.Publisher).ToListAsync();
    
    
        }
    }
}
