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
    public class DetailsModel : GenericPageModel
    {
        private readonly IMapper _mapper;

        public DetailsModel(IMapper mapper)
        {
            _mapper = mapper;
        }

        public CompanyViewModel CompanyVM { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }


            try
            {

                //post data to WebApi
                var companyRestApi = RestService.For<ICompanyRestApi>(RestApiConstants.UrlBase);
                var companie = await companyRestApi.GetById(id);

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
    }
}
