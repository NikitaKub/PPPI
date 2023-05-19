namespace PPPI.Services.Department
{
    using Microsoft.AspNetCore.Mvc;
    using PPPI.Models;

    public class DepartmentData : IDepartmentData
    {
        public List<DepartmentModel> departmentsList = new List<DepartmentModel>()
        {
            new DepartmentModel() {Name = "Department of Technology", Duties = "Smth1", Superior = "Jonathan O.P."},
            new DepartmentModel() {Name = "Department of Computer Technologies", Duties = "Smth2", Superior = "Jonathan O.P."},
            new DepartmentModel() {Name = "Department of Health And Body Positive", Duties = "Smth3", Superior = "Cappey F.D."},
            new DepartmentModel() {Name = "Department of Engineering And Construction", Duties = "Smth4", Superior = "Jay S.V."},
            new DepartmentModel() {Name = "Department of Computer Science", Duties = "Smth5", Superior = "Frenk O.S."},
            new DepartmentModel() {Name = "Department of Command And Social", Duties = "Smth6", Superior = "Verram A.P."},
            new DepartmentModel() {Name = "Department of Relax", Duties = "Smth7", Superior = "Jonathan F.F."},
            new DepartmentModel() {Name = "Department of Universal Solving", Duties = "Smth8", Superior = "Beram O.P."},
            new DepartmentModel() {Name = "Department of AI", Duties = "Smth9", Superior = "Frenk D.P."},
            new DepartmentModel() {Name = "Department of Economy", Duties = "Smth0", Superior = "Babby J.P."}
        };

        public async Task<Response<DepartmentModel>> Delete(int id)
        {
            try
            {
                var value = departmentsList[id];
                await Task.Run(() => departmentsList.RemoveAt(id));
                return new Response<DepartmentModel>()
                {
                    Data = value,
                    StatusCode = new OkResult().StatusCode,
                    Message = "Department removed"
                };
            }
            catch
            {
                return new Response<DepartmentModel>()
                {
                    Data = null,
                    StatusCode = new BadRequestResult().StatusCode,
                    Message = "Department not removed"
                };
            }
        }

        public async Task<Response<DepartmentModel>> Get(int id)
        {
            try
            {
                var value = await Task.Run(() => departmentsList[id]);
                return new Response<DepartmentModel>()
                {
                    Data = value,
                    StatusCode = new OkResult().StatusCode,
                    Message = "Department founded"
                };
            }
            catch
            {
                return new Response<DepartmentModel>()
                {
                    Data = null,
                    StatusCode = new BadRequestResult().StatusCode,
                    Message = "Department not founded"
                };
            }
        }

        public async Task<Response<List<DepartmentModel>>> GetAll()
        {
            try
            {
                var value = await Task.Run(() => departmentsList);
                return new Response<List<DepartmentModel>>()
                {
                    Data = value,
                    StatusCode = new OkResult().StatusCode,
                    Message = "Departments founded"
                };
            }
            catch
            {
                return new Response<List<DepartmentModel>>()
                {
                    Data = null,
                    StatusCode = new BadRequestResult().StatusCode,
                    Message = "Departments not founded"
                };
            }
        }

        public async Task<Response<DepartmentModel>> Post(string name, string duties, string superior)
        {
            try
            {
                await Task.Run(() => departmentsList.Add(new DepartmentModel()
                {
                    Name = name,
                    Duties = duties,
                    Superior = superior
                }));
                var value = departmentsList.Last();
                return new Response<DepartmentModel>()
                {
                    Data = value,
                    StatusCode = new OkResult().StatusCode,
                    Message = "Department added"
                };
            }
            catch (Exception)
            {
                return new Response<DepartmentModel>()
                {
                    Data = null,
                    StatusCode = new BadRequestResult().StatusCode,
                    Message = "Department not added"
                };
            }
        }

        public async Task<Response<DepartmentModel>> Put(int id, string name, string duties, string superior)
        {
            try
            {
                await Task.Run(() => departmentsList[id] = new DepartmentModel()
                {
                    Name = name,
                    Duties = duties,
                    Superior = superior
                }
                );
                var value = departmentsList[id];
                return new Response<DepartmentModel>()
                {
                    Data = value,
                    StatusCode = new OkResult().StatusCode,
                    Message = "Department updated"
                };
            }
            catch
            {
                return new Response<DepartmentModel>()
                {
                    Data = null,
                    StatusCode = new BadRequestResult().StatusCode,
                    Message = "Department not updated"
                };
            }
        }
    }
}
