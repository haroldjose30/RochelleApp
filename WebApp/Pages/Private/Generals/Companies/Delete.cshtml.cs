using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Areas.Identity.Data;
using WebApp.Models;

namespace WebApp.Pages.Companies
{
    public class DeleteModel : PageModel
    {
        private readonly WebApp.Areas.Identity.Data.WebAppIdentityDbContext _context;

        public DeleteModel(WebApp.Areas.Identity.Data.WebAppIdentityDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CompanyVM CompanyVM { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CompanyVM = await _context.CompanyVM.FirstOrDefaultAsync(m => m.Id == id);

            if (CompanyVM == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CompanyVM = await _context.CompanyVM.FindAsync(id);

            if (CompanyVM != null)
            {
                _context.CompanyVM.Remove(CompanyVM);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
