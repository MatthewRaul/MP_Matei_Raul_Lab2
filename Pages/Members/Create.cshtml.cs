using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Matei_Raul_Lab2.Data;
using Matei_Raul_Lab2.Models;

namespace Matei_Raul_Lab2.Pages.Members
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
            return Page();
        }

        [BindProperty]
        public Member Member { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Member.Add(Member);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
