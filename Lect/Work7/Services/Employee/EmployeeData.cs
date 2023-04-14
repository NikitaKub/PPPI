namespace PPPI.Services.Employee
{
    using PPPI.Models;
    public class EmployeeData : IEmployeeData
    {
        public List<Employee> employeesList = new List<Employee>()
        {
            new Employee() {Name = "Jonathan", Surname = "Ostin", Duty = "Smth1"},
            new Employee() {Name = "Jonathan", Surname = "Ornald", Duty = "Smth2"},
            new Employee() {Name = "Cappey", Surname = "Ferly", Duty = "Smth3"},
            new Employee() {Name = "Jay", Surname = "Sin", Duty = "Smth4"},
            new Employee() {Name = "Frenk", Surname = "Oyawa", Duty = "Smth5"},
            new Employee() {Name = "Verram", Surname = "Abrams", Duty = "Smth6"},
            new Employee() {Name = "Jonathan", Surname = "Fedy", Duty = "Smth7"},
            new Employee() {Name = "Beram", Surname = "Onakin", Duty = "Smth8"},
            new Employee() {Name = "Frenk", Surname = "Diykstra", Duty = "Smth9"},
            new Employee() {Name = "Babby", Surname = "Jewlen", Duty = "Smth0"}
        };

        async public Task Delete(int id)
        {
            try
            {
                await Task.Run(() => employeesList.RemoveAt(id));
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
                value = await Task.Run(() => employeesList[id].ToString());
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
            foreach (Employee employee in employeesList)
            {
                value += employee.ToString() + "\n";
            }
            return value;
        }

        async public Task Post(string name, string surname, string duty)
        {
            try
            {
                await Task.Run(() => employeesList.Add(new Employee()
                {
                    Name = name,
                    Surname = surname,
                    Duty = duty
                })
                );
            }
            catch (Exception)
            {
                //await Task.Run(() => Results.StatusCode(400));
            }
        }

        async public Task Put(int id, string name, string surname, string duty)
        {
            try
            {
                await Task.Run(() => employeesList[id] = new Employee()
                {
                    Name = name,
                    Surname = surname,
                    Duty = duty
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
