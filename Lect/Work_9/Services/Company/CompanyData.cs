namespace PPPI.Services.Company
{
    using Microsoft.AspNetCore.Mvc;
    using PPPI.Models;

    public class CompanyData : ICompanyData
    {
        public List<CompanyModel> companiesList = new List<CompanyModel>()
        {
            new CompanyModel() {Name = "MackDack", OfficialName = "T.O. \"MCDonals\"", Owner = "Jonathan O.P."},
            new CompanyModel() {Name = "ForCome", OfficialName = "T.O. \"Come in Time! for\"", Owner = "Jonathan O.P."},
            new CompanyModel() {Name = "Fresh", OfficialName = "T.O. \"Fresh\"", Owner = "Cappey F.D."},
            new CompanyModel() {Name = "Hopkins", OfficialName = "T.O. \"Hopkins J.S.\"", Owner = "Jay S.V."},
            new CompanyModel() {Name = "Folk", OfficialName = "T.O. \"Folk\"", Owner = "Frenk O.S."},
            new CompanyModel() {Name = "AOA", OfficialName = "T.O. \"Atlantic Oasis Aerolines\"", Owner = "Verram A.P."},
            new CompanyModel() {Name = "Friend", OfficialName = "T.O. \"Friendship\"", Owner = "Jonathan F.F."},
            new CompanyModel() {Name = "CanDer", OfficialName = "T.O. \"CanDer\"", Owner = "Beram O.P."},
            new CompanyModel() {Name = "Freeeeeef", OfficialName = "T.O. \"Freeeeeef\"", Owner = "Frenk D.P."},
            new CompanyModel() {Name = "GoranDEVU", OfficialName = "T.O. \"GoranDEVU\"", Owner = "Babby J.P."}
        };

        public async Task<Response<CompanyModel>> Delete(int id)
        {
            try
            {
                var value = companiesList[id];
                await Task.Run(() => companiesList.RemoveAt(id));
                return new Response<CompanyModel>()
                {
                    Data = value,
                    StatusCode = new OkResult().StatusCode,
                    Message = "Company removed"
                };
            }
            catch
            {
                return new Response<CompanyModel>()
                {
                    Data = null,
                    StatusCode = new BadRequestResult().StatusCode,
                    Message = "Company not removed"
                };
            }
        }

        public async Task<Response<CompanyModel>> Get(int id)
        {
            try
            {
                var value = await Task.Run(() => companiesList[id]);
                return new Response<CompanyModel>()
                {
                    Data = value,
                    StatusCode = new OkResult().StatusCode,
                    Message = "Company founded"
                };
            }
            catch
            {
                return new Response<CompanyModel>()
                {
                    Data = null,
                    StatusCode = new BadRequestResult().StatusCode,
                    Message = "Company not founded"
                };
            }
        }

        public async Task<Response<List<CompanyModel>>> GetAll()
        {
            try
            {
                var value = await Task.Run(() => companiesList);
                return new Response<List<CompanyModel>>()
                {
                    Data = value,
                    StatusCode = new OkResult().StatusCode,
                    Message = "Companies founded"
                };
            }
            catch
            {
                return new Response<List<CompanyModel>>()
                {
                    Data = null,
                    StatusCode = new BadRequestResult().StatusCode,
                    Message = "Companies not founded"
                };
            }
        }

        public async Task<Response<CompanyModel>> Post(string name, string officialName, string owner)
        {
            try
            {
                await Task.Run(() => companiesList.Add(new CompanyModel()
                {
                    Name = name,
                    OfficialName = officialName,
                    Owner = owner
                }));
                var value = companiesList.Last();
                return new Response<CompanyModel>()
                {
                    Data = value,
                    StatusCode = new OkResult().StatusCode,
                    Message = "Company added"
                };
            }
            catch (Exception)
            {
                return new Response<CompanyModel>()
                {
                    Data = null,
                    StatusCode = new BadRequestResult().StatusCode,
                    Message = "Company not added"
                };
            }
        }

        public async Task<Response<CompanyModel>> Put(int id, string name, string officialName, string owner)
        {
            try
            {
                await Task.Run(() => companiesList[id] = new CompanyModel()
                {
                    Name = name,
                    OfficialName = officialName,
                    Owner = owner
                }
                );
                var value = companiesList[id];
                return new Response<CompanyModel>()
                {
                    Data = value,
                    StatusCode = new OkResult().StatusCode,
                    Message = "Company updated"
                };
            }
            catch
            {
                return new Response<CompanyModel>()
                {
                    Data = null,
                    StatusCode = new BadRequestResult().StatusCode,
                    Message = "Company not updated"
                };
            }
        }
    }
}
