namespace PPPI.Services.Employee
{
    public interface IEmployeeData
    {
        Task<String> Get(int id);
        Task<String> GetAll();
        Task Post(string name, string surname, string duty);
        Task Put(int id, string name, string surname, string duty);
        Task Delete(int id);
        string forAllList();
    }
}
