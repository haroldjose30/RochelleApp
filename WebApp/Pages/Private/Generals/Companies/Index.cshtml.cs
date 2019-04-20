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
    public class IndexModel : PageModel
    {
        private readonly WebApp.Areas.Identity.Data.WebAppIdentityDbContext _context;

        public IndexModel(WebApp.Areas.Identity.Data.WebAppIdentityDbContext context)
        {
            _context = context;
        }

        public IList<CompanyVM> CompanyVM { get;set; }

        public async Task OnGetAsync()
        {
            CompanyVM = await _context.CompanyVM.ToListAsync();
        }
    }
}
