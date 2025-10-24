using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab2.Models;
using Matei_Raul_Lab2.Data;
using Matei_Raul_Lab2.Models;

namespace Matei_Raul_Lab2.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Matei_Raul_Lab2.Data.Matei_Raul_Lab2Context _context;

        public CreateModel(Matei_Raul_Lab2.Data.Matei_Raul_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var authorList = _context.Authors.Select
                (a => new { a.ID, FullName = a.LastName + " "+ a.FirstName }).ToList();

            ViewData["PublisherID"] = 
                new SelectList(_context.Publisher, "ID", "PublisherName");


            ViewData["AuthorsID"] =
                new SelectList(authorList, "ID", "FullName");



            return Page();

        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var authorList = _context.Authors.Select
                    (a => new { a.ID, FullName = a.LastName + ' ' + a.FirstName }).ToList();
                ViewData["AuthorsID"] = new SelectList(authorList, "ID", "FullName", Book.AuthorsID);
                ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName", Book.PublisherID);

                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
