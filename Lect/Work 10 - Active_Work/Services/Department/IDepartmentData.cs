using PPPI.Models;

namespace PPPI.Services.Department
{
    public interface IDepartmentData
    {
        Task<Response<DepartmentModel>> Get(int id);
        Task<Response<List<DepartmentModel>>> GetAll();
        Task<Response<DepartmentModel>> Post(string name, string duties, string superior);
        Task<Response<DepartmentModel>> Put(int id, string name, string duties, string superior);
        Task<Response<DepartmentModel>> Delete(int id);
    }
}
