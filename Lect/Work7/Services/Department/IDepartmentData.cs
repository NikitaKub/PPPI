namespace PPPI.Services.Department
{
    public interface IDepartmentData
    {
        Task<String> Get(int id);
        Task<String> GetAll();
        Task Post(string name, string duties, string superior);
        Task Put(int id, string name, string duties, string superior);
        Task Delete(int id);
        string forAllList();
    }
}
