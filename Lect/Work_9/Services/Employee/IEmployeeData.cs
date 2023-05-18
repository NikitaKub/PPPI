using PPPI.Models;

namespace PPPI.Services.Employee
{
    public interface IEmployeeData
    {
        Task<Response<EmployeeModel>> Get(int id);
        Task<Response<List<EmployeeModel>>> GetAll();
        Task<Response<EmployeeModel>> Post(string name, string surname, string duty);
        Task<Response<EmployeeModel>> Put(int id, string name, string surname, string duty);
        Task<Response<EmployeeModel>> Delete(int id);
    }
}
