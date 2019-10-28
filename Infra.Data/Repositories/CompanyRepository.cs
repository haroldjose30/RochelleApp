using System;
using System.Diagnostics;
using Domain.Generals;
using Domain.Interfaces;
using Infra.Data.Context;
using Infra.Data.Repositories.Base;

namespace Infra.Data.Repositories
{

    
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(DbContextGeneric context)
            : base(context)
        {
            Debug.WriteLine("Company");
        }
    }
    
}