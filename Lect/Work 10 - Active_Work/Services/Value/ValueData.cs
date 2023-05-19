using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using PPPI.Models;
using System.Net;
using System.Net.Http.Headers;

namespace PPPI.Services.Value
{
    public class ValueData : IValueData
    {
        public ValueData() {}
        
        public async Task<Response<int>> GetV1()
        {
            try
            {
                return new Response<int>()
                {
                    StatusCode = new OkResult().StatusCode,
                    Data = 200,
                    Message = "Version 1.0 OK",
                };
            }
            catch {
                return new Response<int>()
                {
                    StatusCode = new BadRequestResult().StatusCode,
                    Data = 400,
                    Message = "Version 1.0 Bad",
                };
            }
        }

        public async Task<Response<string>> GetV2()
        {
            try
            {
                return new Response<string>()
                {
                    StatusCode = new OkResult().StatusCode,
                    Data = "200",
                    Message = "Version 2.0 OK",
                };
            }
            catch
            {
                return new Response<string>()
                {
                    StatusCode = new BadRequestResult().StatusCode,
                    Data = "400",
                    Message = "Version 2.0 Bad",
                };
            }
        }

        public async Task<Response<HttpResponseMessage>> GetV3()
        {
            try
            {
                XLWorkbook workbook = new XLWorkbook();
                workbook.Worksheets.Add("Sample").Cell(1, 1).SetValue("Hello World");

                HttpResponseMessage response = null;

                using (var memoryStream = new MemoryStream())
                {

                    workbook.SaveAs(memoryStream);

                    memoryStream.Seek(0, SeekOrigin.Begin);

                    response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StreamContent(memoryStream);
                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                    response.Content.Headers.ContentDisposition.FileName = "HelloWorld.xlsx";
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

                    response.Content.Headers.ContentLength = memoryStream.Length;
                    memoryStream.Seek(0, SeekOrigin.Begin);
                }
                return new Response<HttpResponseMessage>()
                {
                    StatusCode = new OkResult().StatusCode,
                    Data = response,
                    Message = "Version 3.0 OK",
                };
            }
            catch
            {
                XLWorkbook workbook = new XLWorkbook();
                workbook.Worksheets.Add("Sample").Cell(1, 1).SetValue("Bad Request");

                HttpResponseMessage response = null;

                using (var memoryStream = new MemoryStream())
                {

                    workbook.SaveAs(memoryStream);

                    memoryStream.Seek(0, SeekOrigin.Begin);

                    response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StreamContent(memoryStream);
                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                    response.Content.Headers.ContentDisposition.FileName = "BadXL.xlsx";
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

                    response.Content.Headers.ContentLength = memoryStream.Length;
                    memoryStream.Seek(0, SeekOrigin.Begin);
                }


                return new Response<HttpResponseMessage>()
                {
                    StatusCode = new BadRequestResult().StatusCode,
                    Data = response,
                    Message = "Version 3.0 Bad",
                };
            }
        }
    }
}
