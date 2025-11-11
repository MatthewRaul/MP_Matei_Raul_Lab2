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

namespace Matei_Raul_Lab2.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly Matei_Raul_Lab2.Data.Matei_Raul_Lab2Context _context;

        public IndexModel(Matei_Raul_Lab2.Data.Matei_Raul_Lab2Context context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get;set; } = default!;

        public PublisherIndexData PublisherData { get; set; }
        public int PublisherID { get; set; }
        public int BookID { get; set; }

        public async Task OnGetAsync(int? id, int? bookID)
        {
            PublisherData = new PublisherIndexData();

            PublisherData.Publishers = await _context.Publisher
                .Include(i => i.Books)
                    .ThenInclude(b => b.Authors) 
                .OrderBy(i => i.PublisherName)
                .AsNoTracking()
                .ToListAsync();

            if (id != null)
            {
                PublisherID = id.Value;
                var publisher = PublisherData.Publishers
                    .Where(i => i.ID == id.Value)
                    .Single();
                PublisherData.Books = publisher.Books;
            }
        }

    }
}
