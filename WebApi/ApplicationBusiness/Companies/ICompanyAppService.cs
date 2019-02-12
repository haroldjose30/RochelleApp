using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Generals;

namespace ApplicationBusiness.Companies.Services
{
    public interface ICompanyAppService : IDisposable
    {
        Company Register(Company compnay);
        Task<IEnumerable<Company>> GetAllAsync();
        Company GetById(string id);
        Company Update(Company compnay);
        bool Remove(string id, string removedBy);
    }
}
