using System.Threading.Tasks;
using AutoMapper;
using Domain.Generals;
using Microsoft.AspNetCore.Mvc;
using Refit;
using WebApp.Constants;
using WebApp.Models;
using WebApp.Pages.Private.Base;
using WebApp.Services;

namespace WebApp.Pages.Companies
{
    public class CreateModel : GenericPageModel
    {
        private readonly IMapper _mapper;

        public CreateModel(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CompanyViewModel CompanyVM { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Convert Data from WebApi
            CompanyVM.CreatedBy = User.Identity.Name;
            CompanyVM.ModifiedBy = CompanyVM.CreatedBy;
            var companie  = _mapper.Map<CompanyViewModel,Company >(CompanyVM);

           
            try
            {
                //post data to WebApi
                var companyRestApi = RestService.For<ICompanyRestApi>(RestApiConstants.UrlBase);
                var companies = await companyRestApi.Add(companie);

                return RedirectToPage("./Index");
            }
            catch (ApiException ex)
            {
                errorMessage = await ex.GetContentAsAsync<ErrorMessage>();
                return Page();
            }





        }
    }

   

}