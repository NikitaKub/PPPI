using ClosedXML.Excel;
using PPPI.Models;

namespace PPPI.Services.Value
{
    public interface IValueData
    {
        Task<Response<int>> GetV1();
        Task<Response<string>> GetV2();
        Task<Response<HttpResponseMessage>> GetV3();
    }
}
