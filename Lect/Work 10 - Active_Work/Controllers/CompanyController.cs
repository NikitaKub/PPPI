using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PPPI.Models;
using PPPI.Services.Company;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PPPI.Controllers
{
    [ApiVersion("3.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyData _companyData;

        public CompanyController(ICompanyData companyData)
        {
            _companyData = companyData;
        }

        [HttpGet("{id}"), Authorize]
        public async Task<Response<CompanyModel>> Get(int id)
        {
            Response<CompanyModel>? response = await _companyData.Get(id);
            return response;
        }

        [HttpGet, Authorize]
        public async Task<Response<List<CompanyModel>>> GetAll()
        {
            Response<List<CompanyModel>>? response = await _companyData.GetAll();
            return response;
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<Response<CompanyModel>> Post([FromQuery] string name, [FromQuery] string officialName, [FromQuery] string owner)
        {
            Response<CompanyModel>? response = await _companyData.Post(name, officialName, owner);
            return response;
        }

        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public async Task<Response<CompanyModel>> Put(int id, [FromQuery] string name, [FromQuery] string officialName, [FromQuery] string owner)
        {
            Response<CompanyModel>? response = await _companyData.Put(id, name, officialName, owner);
            return response;
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<Response<CompanyModel>> Delete(int id)
        {
            Response<CompanyModel>? response = await _companyData.Delete(id);
            return response;
        }
    }
}
