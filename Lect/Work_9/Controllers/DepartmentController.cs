using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PPPI.Models;
using PPPI.Services.Department;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PPPI.Controllers
{
    [ApiVersion("3.0")]
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
        [HttpGet("{id}"), Authorize]
        public async Task<Response<DepartmentModel>> Get(int id)
        {
            Response<DepartmentModel>? response = await _departmentData.Get(id);
            return response;
        }

        // GETALL api/<CompanyController>
        [HttpGet, Authorize]
        public async Task<Response<List<DepartmentModel>>> GetAll()
        {
            Response<List<DepartmentModel>>? response = await _departmentData.GetAll();
            return response;
        }

        // POST api/<CompanyController>
        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<Response<DepartmentModel>> Post([FromQuery] string name, [FromQuery] string duties, [FromQuery] string superior)
        {
            Response<DepartmentModel>? response = await _departmentData.Post(name, duties, superior);
            return response;
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public async Task<Response<DepartmentModel>> Put(int id, [FromQuery] string name, [FromQuery] string duties, [FromQuery] string superior)
        {
            Response<DepartmentModel>? response = await _departmentData.Put(id, name, duties, superior);
            return response;
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<Response<DepartmentModel>> Delete(int id)
        {
            Response<DepartmentModel>? response = await _departmentData.Delete(id);
            return response;
        }
    }
}
