using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RochelleServer.Repositories;
using RochelleShared.Models;


namespace RochelleServer.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository repository;
        public CompanyController(ICompanyRepository _repository)
        {
            repository = _repository;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<Company>> Get()
        {
             return await repository.GetAllAsync();
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Company> Get(string id)
        {
            return await repository.GetByIdAsync(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<Company> Post([FromBody]Company company)
        {
            return await repository.CreateAsync(company);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<Company> Put([FromBody]Company company)
        {
            return await repository.UpdateAsync(company);
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<bool> Delete([FromBody]Company company)
        {
            return await repository.DeleteAsync(company);
        }

    }
}
