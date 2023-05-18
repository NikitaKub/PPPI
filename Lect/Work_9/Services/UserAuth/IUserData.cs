using PPPI.Models;

namespace PPPI.Services.UserAuth
{
    public interface IUserData
    {
        Task<Response<string>> Login(LoginModel loginModel);
        Task<Response<User>> Registration(RegistrationModel registrationModel);
    }
}
