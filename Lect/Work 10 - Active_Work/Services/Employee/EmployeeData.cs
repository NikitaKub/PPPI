namespace PPPI.Services.Employee
{
    using Microsoft.AspNetCore.Mvc;
    using PPPI.Models;

    public class EmployeeData : IEmployeeData
    {
        public List<EmployeeModel> employeesList = new List<EmployeeModel>()
        {
            new EmployeeModel() {Name = "Jonathan", Surname = "Ostin", Duty = "Smth1"},
            new EmployeeModel() {Name = "Jonathan", Surname = "Ornald", Duty = "Smth2"},
            new EmployeeModel() {Name = "Cappey", Surname = "Ferly", Duty = "Smth3"},
            new EmployeeModel() {Name = "Jay", Surname = "Sin", Duty = "Smth4"},
            new EmployeeModel() {Name = "Frenk", Surname = "Oyawa", Duty = "Smth5"},
            new EmployeeModel() {Name = "Verram", Surname = "Abrams", Duty = "Smth6"},
            new EmployeeModel() {Name = "Jonathan", Surname = "Fedy", Duty = "Smth7"},
            new EmployeeModel() {Name = "Beram", Surname = "Onakin", Duty = "Smth8"},
            new EmployeeModel() {Name = "Frenk", Surname = "Diykstra", Duty = "Smth9"},
            new EmployeeModel() {Name = "Babby", Surname = "Jewlen", Duty = "Smth0"}
        };

        public async Task<Response<EmployeeModel>> Delete(int id)
        {
            try
            {
                var value = employeesList[id];
                await Task.Run(() => employeesList.RemoveAt(id));
                return new Response<EmployeeModel>()
                {
                    Data = value,
                    StatusCode = new OkResult().StatusCode,
                    Message = "Employee removed"
                };
            }
            catch
            {
                return new Response<EmployeeModel>()
                {
                    Data = null,
                    StatusCode = new BadRequestResult().StatusCode,
                    Message = "Employee not removed"
                };
            }
        }

        public async Task<Response<EmployeeModel>> Get(int id)
        {
            try
            {
                var value = await Task.Run(() => employeesList[id]);
                return new Response<EmployeeModel>()
                {
                    Data = value,
                    StatusCode = new OkResult().StatusCode,
                    Message = "Employee founded"
                };
            }
            catch
            {
                return new Response<EmployeeModel>()
                {
                    Data = null,
                    StatusCode = new BadRequestResult().StatusCode,
                    Message = "Employee not founded"
                };
            }
        }

        public async Task<Response<List<EmployeeModel>>> GetAll()
        {
            try
            {
                var value = await Task.Run(() => employeesList);
                return new Response<List<EmployeeModel>>()
                {
                    Data = value,
                    StatusCode = new OkResult().StatusCode,
                    Message = "Employees founded"
                };
            }
            catch
            {
                return new Response<List<EmployeeModel>>()
                {
                    Data = null,
                    StatusCode = new BadRequestResult().StatusCode,
                    Message = "Employees not founded"
                };
            }
        }

        public async Task<Response<EmployeeModel>> Post(string name, string surname, string duty)
        {
            try
            {
                await Task.Run(() => employeesList.Add(new EmployeeModel()
                {
                    Name = name,
                    Surname = surname,
                    Duty = duty
                }));
                var value = employeesList.Last();
                return new Response<EmployeeModel>()
                {
                    Data = value,
                    StatusCode = new OkResult().StatusCode,
                    Message = "Employee added"
                };
            }
            catch (Exception)
            {
                return new Response<EmployeeModel>()
                {
                    Data = null,
                    StatusCode = new BadRequestResult().StatusCode,
                    Message = "Employee not added"
                };
            }
        }

        public async Task<Response<EmployeeModel>> Put(int id, string name, string surname, string duty)
        {
            try
            {
                await Task.Run(() => employeesList[id] = new EmployeeModel()
                {
                    Name = name,
                    Surname = surname,
                    Duty = duty
                }
                );
                var value = employeesList[id];
                return new Response<EmployeeModel>()
                {
                    Data = value,
                    StatusCode = new OkResult().StatusCode,
                    Message = "Employee updated"
                };
            }
            catch
            {
                return new Response<EmployeeModel>()
                {
                    Data = null,
                    StatusCode = new BadRequestResult().StatusCode,
                    Message = "Employee not updated"
                };
            }
        }
    }
}
