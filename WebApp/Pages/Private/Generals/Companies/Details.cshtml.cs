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
    public class DetailsModel : PageModel
    {
        private readonly WebApp.Areas.Identity.Data.WebAppIdentityDbContext _context;

        public DetailsModel(WebApp.Areas.Identity.Data.WebAppIdentityDbContext context)
        {
            _context = context;
        }

        public CompanyViewModel CompanyVM { get; set; }

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
    }
}
