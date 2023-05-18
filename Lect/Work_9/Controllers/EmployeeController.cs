using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PPPI.Models;
using PPPI.Services.Employee;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PPPI.Controllers
{
    [ApiVersion("3.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeData _employeeData;

        public EmployeeController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}"), Authorize]
        public async Task<Response<EmployeeModel>> Get(int id)
        {
            Response<EmployeeModel>? response = await _employeeData.Get(id);
            return response;
        }

        // GETALL api/<CompanyController>
        [HttpGet, Authorize]
        public async Task<Response<List<EmployeeModel>>> GetAll()
        {
            Response<List<EmployeeModel>>? response = await _employeeData.GetAll();
            return response;
        }

        // POST api/<CompanyController>
        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<Response<EmployeeModel>> Post([FromQuery] string name, [FromQuery] string surname, [FromQuery] string duty)
        {
            Response<EmployeeModel>? response = await _employeeData.Post(name, surname, duty);
            return response;
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public async Task<Response<EmployeeModel>> Put(int id, [FromQuery] string name, [FromQuery] string surname, [FromQuery] string duty)
        {
            Response<EmployeeModel>? response = await _employeeData.Put(id, name, surname, duty);
            return response;
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<Response<EmployeeModel>> Delete(int id)
        {
            Response<EmployeeModel>? response = await _employeeData.Delete(id);
            return response;
        }
    }
}
