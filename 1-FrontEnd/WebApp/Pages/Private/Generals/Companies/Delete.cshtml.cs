using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Generals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Refit;
using WebApp.Areas.Identity.Data;
using WebApp.Constants;
using WebApp.Models;
using WebApp.Pages.Private.Base;
using WebApp.Services;

namespace WebApp.Pages.Companies
{
    public class DeleteModel : GenericPageModel
    {
        private readonly IMapper _mapper;

        public DeleteModel(IMapper mapper)
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
                var companie = await companyRestApi.GetById(id);

                if (companie == null)
                {
                    return NotFound();
                }

                CompanyVM = _mapper.Map<Company, CompanyViewModel>(companie);

            }
            catch (ApiException ex)
            {
                errorMessage = await ex.GetContentAsAsync<ErrorMessage>();
                return Page();
            }


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

            try
            {
                //instance WebApi
                var companyRestApi = RestService.For<ICompanyRestApi>(RestApiConstants.UrlBase);
           
                await companyRestApi.Remove(CompanyVM.Id, User.Identity.Name);
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
