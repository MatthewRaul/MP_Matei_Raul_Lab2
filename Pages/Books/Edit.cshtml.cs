using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab2.Models;
using Matei_Raul_Lab2.Data;
using Matei_Raul_Lab2.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Matei_Raul_Lab2.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly Matei_Raul_Lab2.Data.Matei_Raul_Lab2Context _context;

        public EditModel(Matei_Raul_Lab2.Data.Matei_Raul_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Book = await _context.Book.Include(b => b.Authors).Include(b => b.Publisher)
                .AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);
           
            if (Book == null)
            {
                return NotFound();
            }
            var authorList = _context.Authors.Select(a => new
            {
                a.ID,
                FullName = a.LastName + ' '
            + a.FirstName
            }).ToList();
            ViewData["PublisherID"] = 
                new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            ViewData["AuthorsID"] = 
                new SelectList(authorList, "ID", "FullName",Book.AuthorsID);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var authorList = _context.Authors.Select(a => new
                {
                    a.ID,
                    FullName = a.LastName + ' ' + a.FirstName
                }).ToList();
                ViewData["AuthorsID"] = new SelectList(authorList, "ID", "FullName",Book.AuthorsID);

                ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName", Book.PublisherID);
                return Page();
            }

            _context.Attach(Book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Book.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.ID == id);
        }
    }
}
