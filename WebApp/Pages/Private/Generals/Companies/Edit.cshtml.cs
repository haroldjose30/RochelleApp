using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Generals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Refit;
using WebApp.Areas.Identity.Data;
using WebApp.Constants;
using WebApp.Models;
using WebApp.Pages.Private.Base;
using WebApp.Services;

namespace WebApp.Pages.Companies
{
    public class EditModel : GenericPageModel
    {
        private readonly IMapper _mapper;

        public EditModel(IMapper mapper)
        {
            _mapper = mapper;
        }

        [BindProperty]
        public CompanyViewModel CompanyVM { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyRestApi = RestService.For<ICompanyRestApi>(RestApiConstants.UrlBase);
            var companie = await companyRestApi.GetById(id);

            if (companie == null)
            {
                return NotFound();
            }

            CompanyVM = _mapper.Map<Company, CompanyViewModel>(companie);

            return Page();
        }






        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

          
            try
            {
                parei aqui
                //o view model deve conter todos os campos pois caso contrario ira limpar os campos que nao forem carregados
                var companie = _mapper.Map<CompanyViewModel,Company>(CompanyVM);
                var companyRestApi = RestService.For<ICompanyRestApi>(RestApiConstants.UrlBase);
                await companyRestApi.Update(companie);

            }
            catch (ApiException ex)
            {
                errorMessage = await ex.GetContentAsAsync<ErrorMessage>();
                return Page();
            }


            return RedirectToPage("./Index");
        }
    }
}
