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

         
            try
            {
                var companyRestApi = RestService.For<ICompanyRestApi>(RestApiConstants.UrlBase);
                var company = await companyRestApi.GetById(id);

                if (company == null)
                {
                    return NotFound();
                }

                CompanyVM = _mapper.Map<Company, CompanyViewModel>(company);

            }
            catch (ApiException ex)
            {
                errorMessage = await ex.GetContentAsAsync<ErrorMessage>();
                return Page();
            }


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
                //update current user
                CompanyVM.ModifiedBy = User.Identity.Name;

                //instance WebApi
                var companyRestApi = RestService.For<ICompanyRestApi>(RestApiConstants.UrlBase);

                //get the original data from database
                var company = await companyRestApi.GetById(CompanyVM.Id);

                //Do automapper to update data from database model
                company = _mapper.Map<CompanyViewModel,Company>(CompanyVM, company);
                await companyRestApi.Update(company);
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
