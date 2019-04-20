using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Areas.Identity.Data;
using WebApp.Models;

namespace WebApp.Pages.Companies
{
    public class CreateModel : PageModel
    {
        private readonly WebApp.Areas.Identity.Data.WebAppIdentityDbContext _context;

        public CreateModel(WebApp.Areas.Identity.Data.WebAppIdentityDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CompanyVM CompanyVM { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CompanyVM.Add(CompanyVM);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}