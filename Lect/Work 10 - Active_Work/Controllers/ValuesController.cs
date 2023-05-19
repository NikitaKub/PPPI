using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PPPI.Models;
using PPPI.Services.Value;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PPPI.Controllers
{
    [ApiVersion("1.0", Deprecated = true)]
    [ApiVersion("2.0")]
    [ApiVersion("3.0")]
    [Route("api/{version:apiVersion}/[controller]")]
    [ApiController, Authorize]
    public class ValuesController : ControllerBase
    {
        private readonly IValueData _valueData1;
        public ValuesController(IValueData valueData) {
            _valueData1 = valueData;
        }

        [HttpGet(), MapToApiVersion("1.0")]
        public async Task<Response<int>> Get1()
        {
            Response<int>? response = await _valueData1.GetV1();
            return response;
        }

        [HttpGet(), MapToApiVersion("2.0")]
        public async Task<Response<string>> Get2()
        {
            Response<string>? response = await _valueData1.GetV2();
            return response;
        }

        [HttpGet(), MapToApiVersion("3.0")]
        public async Task<Response<HttpResponseMessage>> Get3()
        {
            Response<HttpResponseMessage>? response = await _valueData1.GetV3();
            return response;
        }
    }
}
