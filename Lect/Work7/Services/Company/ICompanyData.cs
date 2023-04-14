namespace PPPI.Services.Company
{
    public interface ICompanyData
    {
        Task<String> Get(int id);
        Task<String> GetAll();
        Task Post(string name, string officialName, string owner);
        Task Put(int id, string name, string officialName, string owner);
        Task Delete(int id);
        string forAllList();
    }
}
