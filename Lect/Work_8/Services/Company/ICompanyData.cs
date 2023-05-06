using PPPI.Models;

namespace PPPI.Services.Company
{
    public interface ICompanyData
    {
        Task<Response<CompanyModel>> Get(int id);
        Task<Response<List<CompanyModel>>> GetAll();
        Task<Response<CompanyModel>> Post(string name, string officialName, string owner);
        Task<Response<CompanyModel>> Put(int id, string name, string officialName, string owner);
        Task<Response<CompanyModel>> Delete(int id);
    }
}
