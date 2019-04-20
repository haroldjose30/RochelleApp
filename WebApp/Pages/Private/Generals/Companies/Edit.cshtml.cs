using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Areas.Identity.Data;
using WebApp.Models;

namespace WebApp.Pages.Companies
{
    public class EditModel : PageModel
    {
        private readonly WebApp.Areas.Identity.Data.WebAppIdentityDbContext _context;

        public EditModel(WebApp.Areas.Identity.Data.WebAppIdentityDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CompanyVM).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyVMExists(CompanyVM.Id))
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

        private bool CompanyVMExists(string id)
        {
            return _context.CompanyVM.Any(e => e.Id == id);
        }
    }
}
