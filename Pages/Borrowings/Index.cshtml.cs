using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Matei_Raul_Lab2.Data;
using Matei_Raul_Lab2.Models;

namespace Matei_Raul_Lab2.Pages.Borrowings
{
    public class IndexModel : PageModel
    {
        private readonly Matei_Raul_Lab2.Data.Matei_Raul_Lab2Context _context;

        public IndexModel(Matei_Raul_Lab2.Data.Matei_Raul_Lab2Context context)
        {
            _context = context;
        }

        public IList<Borrowing> Borrowing { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Borrowing = await _context.Borrowing
                .Include(b => b.Member)
                .Include(b => b.Book)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
