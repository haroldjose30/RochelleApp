using ApplicationBusiness.Services;
using Domain.Generals;
using Domain.Generals.Companies.Commands;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyAppService _companyAppService;

        public CompanyController(
           ICompanyAppService companyAppService
            ) 
        {
            _companyAppService = companyAppService;
        }

        [HttpGet]
        //[AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(_companyAppService.GetAll());
            //return Ok("teste");
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var company = _companyAppService.GetById(id);

            return Ok(company);
        }     

        [HttpPost]
        public IActionResult Post([FromBody]Company company)
        {
            var _company = _companyAppService.Register(company);

             return Ok(company);
        }
        
        [HttpPut]
        public IActionResult Put([FromBody]Company company)
        {
            _companyAppService.Update(company);

            return Ok(company);
        }

        [HttpDelete]
        public IActionResult Delete(string id, string removedBy)
        {
            _companyAppService.Remove(id, removedBy);
            
            return Ok();
        }
    }
}
