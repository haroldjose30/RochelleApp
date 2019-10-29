using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Generals;
using Refit;

namespace WebApp.Services
{
    public interface ICompanyRestApi
    {
        [Get("/Companies")]
        Task<List<Company>> GetAll();

        [Get("/Companies/{id}")]
        Task<Company> GetById(string id);

        [Post("/Companies")]
        Task<Company> Add(Company company);

        [Put("/Companies")]
        Task<Company> Update(Company company);

        [Delete("/Companies/{id}/{deletedBy}")]
        Task<bool> Remove(string id,string deletedBy);
    }
   
}
