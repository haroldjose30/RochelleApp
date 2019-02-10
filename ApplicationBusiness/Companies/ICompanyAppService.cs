using System;
using System.Collections.Generic;
using Domain.Generals;
using Domain.Generals.Companies.Commands;

namespace ApplicationBusiness.Services
{
    public interface ICompanyAppService : IDisposable
    {
        Company Register(Company compnay);
        IEnumerable<Company> GetAll();
        Company GetById(string id);
        Company Update(Company compnay);
        bool Remove(string id, string removedBy);
    }
}
