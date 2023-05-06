namespace PPPI.Services.Company
{
    using PPPI.Models;

    public class CompanyData : ICompanyData
    {
        public List<Company> companiesList = new List<Company>()
        {
            new Company() {Name = "MackDack", OfficialName = "T.O. \"MCDonals\"", Owner = "Jonathan O.P."},
            new Company() {Name = "ForCome", OfficialName = "T.O. \"Come in Time! for\"", Owner = "Jonathan O.P."},
            new Company() {Name = "Fresh", OfficialName = "T.O. \"Fresh\"", Owner = "Cappey F.D."},
            new Company() {Name = "Hopkins", OfficialName = "T.O. \"Hopkins J.S.\"", Owner = "Jay S.V."},
            new Company() {Name = "Folk", OfficialName = "T.O. \"Folk\"", Owner = "Frenk O.S."},
            new Company() {Name = "AOA", OfficialName = "T.O. \"Atlantic Oasis Aerolines\"", Owner = "Verram A.P."},
            new Company() {Name = "Friend", OfficialName = "T.O. \"Friendship\"", Owner = "Jonathan F.F."},
            new Company() {Name = "CanDer", OfficialName = "T.O. \"CanDer\"", Owner = "Beram O.P."},
            new Company() {Name = "Freeeeeef", OfficialName = "T.O. \"Freeeeeef\"", Owner = "Frenk D.P."},
            new Company() {Name = "GoranDEVU", OfficialName = "T.O. \"GoranDEVU\"", Owner = "Babby J.P."}
        };

        async public Task Delete(int id)
        {
            try{
                await Task.Run(() => companiesList.RemoveAt(id));
            }
            catch(IndexOutOfRangeException)
            {
                //await Task.Run(() => Results.StatusCode(404));
            }
            catch
            {
                //await Task.Run(() => Results.StatusCode(400));
            }
        }

        async public Task<String> Get(int id)
        {
            string value = "";
            try
            {
                value = await Task.Run(() => companiesList[id].ToString()); 
            }
            catch (IndexOutOfRangeException)
            {
                //await Task.Run(() => Results.StatusCode(404));
            }
            catch
            {
                //await Task.Run(() => Results.StatusCode(400));
            }
            return value;
        }

        async public Task<string> GetAll()
        {
            string value = "";
            try
            {
                value = await Task.Run(() => forAllList());
            }
            catch (IndexOutOfRangeException)
            {
                //await Task.Run(() => Results.StatusCode(404));
            }
            catch
            {
                //await Task.Run(() => Results.StatusCode(400));
            }
            return value;
        }

        public string forAllList()
        {
            string value = "";
            foreach(Company company in companiesList)
            {
                value += company.ToString() + "\n";
            }
            return value;
        }

        async public Task Post(string name, string officialName, string owner)
        {
            try
            {
                await Task.Run(() => companiesList.Add(new Company()
                {
                    Name = name, OfficialName = officialName, Owner = owner
                })
                );
            }
            catch (Exception)
            {
                //await Task.Run(() => Results.StatusCode(400));
            }
        }

        async public Task Put(int id, string name, string officialName, string owner)
        {
            try
            {
                await Task.Run(() => companiesList[id] = new Company()
                {
                    Name = name, OfficialName = officialName, Owner = owner
                }
                );
            }
            catch (IndexOutOfRangeException)
            {
                //await Task.Run(() => Results.StatusCode(404));
            }
            catch
            {
                //await Task.Run(() => Results.StatusCode(400));
            }
        }
    }
}
