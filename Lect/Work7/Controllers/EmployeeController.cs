using Microsoft.AspNetCore.Mvc;
using PPPI.Services.Employee;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PPPI.Controllers
{
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
        [HttpGet("{id}")]
        public async Task<String> Get(int id)
        {
            return await _employeeData.Get(id);
        }

        // GETALL api/<CompanyController>
        [HttpGet]
        public async Task<String> GetAll()
        {
            return await _employeeData.GetAll();
        }

        // POST api/<CompanyController>
        [HttpPost]
        public async Task Post([FromQuery] string name, [FromQuery] string surname, [FromQuery] string duty)
        {
            await _employeeData.Post(name, surname, duty);
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromQuery] string name, [FromQuery] string surname, [FromQuery] string duty)
        {
            await _employeeData.Put(id, name, surname, duty);
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _employeeData.Delete(id);
        }
    }
}
