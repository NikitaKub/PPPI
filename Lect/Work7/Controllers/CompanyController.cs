using Microsoft.AspNetCore.Mvc;
using PPPI.Services.Company;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PPPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyData _companyData;

        public CompanyController(ICompanyData companyData) { 
            _companyData = companyData;
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public async Task<String> Get(int id)
        {
            return await _companyData.Get(id);
        }

        // GETALL api/<CompanyController>
        [HttpGet]
        public async Task<String> GetAll()
        {
            return await _companyData.GetAll();
        }

        // POST api/<CompanyController>
        [HttpPost]
        public async Task Post([FromQuery] string name, [FromQuery] string officialName, [FromQuery] string owner)
        {
            await _companyData.Post(name, officialName, owner);
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromQuery] string name, [FromQuery] string officialName, [FromQuery] string owner)
        {
            await _companyData.Put(id, name, officialName, owner);
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _companyData.Delete(id);
        }
    }
}
