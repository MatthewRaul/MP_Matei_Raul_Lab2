using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Matei_Raul_Lab2.Data;
using Matei_Raul_Lab2.Models;

namespace Matei_Raul_Lab2.Pages.Borrowings
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
            ViewData["MemberID"] = new SelectList(
                _context.Member.OrderBy(m => m.LastName).ThenBy(m => m.FirstName),
                "ID", "FullName");
            ViewData["BookID"] = new SelectList(
                _context.Book.OrderBy(b => b.Title),
                "ID", "Title");
            return Page();
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["MemberID"] = new SelectList(
                    _context.Member.OrderBy(m => m.LastName).ThenBy(m => m.FirstName),
                    "ID", "FullName", Borrowing.MemberID);
                ViewData["BookID"] = new SelectList(
                    _context.Book.OrderBy(b => b.Title),
                    "ID", "Title", Borrowing.BookID);
                return Page();
            }
            _context.Borrowing.Add(Borrowing);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
