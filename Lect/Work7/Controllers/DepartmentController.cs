using Microsoft.AspNetCore.Mvc;
using PPPI.Services.Department;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PPPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentData _departmentData;

        public DepartmentController(IDepartmentData departmentData)
        {
            _departmentData = departmentData;
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public async Task<String> Get(int id)
        {
            return await _departmentData.Get(id);
        }

        // GETALL api/<CompanyController>
        [HttpGet]
        public async Task<String> GetAll()
        {
            return await _departmentData.GetAll();
        }

        // POST api/<CompanyController>
        [HttpPost]
        public async Task Post([FromQuery] string name, [FromQuery] string duties, [FromQuery] string superior)
        {
            await _departmentData.Post(name, duties, superior);
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromQuery] string name, [FromQuery] string duties, [FromQuery] string superior)
        {
            await _departmentData.Put(id, name, duties, superior);
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _departmentData.Delete(id);
        }
    }
}
