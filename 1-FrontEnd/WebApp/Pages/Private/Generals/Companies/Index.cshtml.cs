using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Generals;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Refit;
using WebApp.Areas.Identity.Data;
using WebApp.Constants;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Pages.Companies
{
    public class IndexModel : PageModel
    {
        private readonly IMapper _mapper;

        public IndexModel(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<CompanyViewModel> CompanyVM { get;set; }

        public async Task OnGetAsync()       
        {
            //get data from WebApi
            var companyRestApi = RestService.For<ICompanyRestApi>(RestApiConstants.UrlBase);
            var companies = await companyRestApi.GetAll();

            //Convert Data from WebApi
            CompanyVM = _mapper.Map<List<Company>, List<CompanyViewModel>>(companies);

        }
    }
}
