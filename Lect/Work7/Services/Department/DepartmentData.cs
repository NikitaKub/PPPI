namespace PPPI.Services.Department
{
    using PPPI.Models;

    public class DepartmentData : IDepartmentData
    {
        public List<Department> departmentsList = new List<Department>()
        {
            new Department() {Name = "Department of Technology", Duties = "Smth1", Superior = "Jonathan O.P."},
            new Department() {Name = "Department of Computer Technologies", Duties = "Smth2", Superior = "Jonathan O.P."},
            new Department() {Name = "Department of Health And Body Positive", Duties = "Smth3", Superior = "Cappey F.D."},
            new Department() {Name = "Department of Engineering And Construction", Duties = "Smth4", Superior = "Jay S.V."},
            new Department() {Name = "Department of Computer Science", Duties = "Smth5", Superior = "Frenk O.S."},
            new Department() {Name = "Department of Command And Social", Duties = "Smth6", Superior = "Verram A.P."},
            new Department() {Name = "Department of Relax", Duties = "Smth7", Superior = "Jonathan F.F."},
            new Department() {Name = "Department of Universal Solving", Duties = "Smth8", Superior = "Beram O.P."},
            new Department() {Name = "Department of AI", Duties = "Smth9", Superior = "Frenk D.P."},
            new Department() {Name = "Department of Economy", Duties = "Smth0", Superior = "Babby J.P."}
        };

        async public Task Delete(int id)
        {
            try
            {
                await Task.Run(() => departmentsList.RemoveAt(id));
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

        async public Task<String> Get(int id)
        {
            string value = "";
            try
            {
                value = await Task.Run(() => departmentsList[id].ToString());
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
            foreach (Department department in departmentsList)
            {
                value += department.ToString() + "\n";
            }
            return value;
        }

        async public Task Post(string name, string duties, string superior)
        {
            try
            {
                await Task.Run(() => departmentsList.Add(new Department()
                {
                    Name = name,
                    Duties = duties,
                    Superior = superior
                })
                );
            }
            catch (Exception)
            {
                //await Task.Run(() => Results.StatusCode(400));
            }
        }

        async public Task Put(int id, string name, string duties, string superior)
        {
            try
            {
                await Task.Run(() => departmentsList[id] = new Department()
                {
                    Name = name,
                    Duties = duties,
                    Superior = superior
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
