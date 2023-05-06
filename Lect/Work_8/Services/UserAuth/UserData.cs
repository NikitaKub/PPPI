namespace PPPI.Services.UserAuth
{
    using Microsoft.AspNetCore.Components.Forms;
    using Microsoft.AspNetCore.Cryptography.KeyDerivation;
    using PPPI.Models;
    using PPPI.Services.SecurityConvert;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using System.IdentityModel.Tokens.Jwt;
    using System.Xml.Linq;
    using PPPI.Services.JWTGenerator;
    using Microsoft.AspNetCore.Mvc;

    public class UserData : IUserData
    {
        private readonly ISecurityConvertData _securityConvertData;
        private readonly IJWTGenerator _jwtGenerator;
        private List<User> usersList;

        public UserData(ISecurityConvertData securityConvertData, IJWTGenerator jWTGenerator)
        {
            _securityConvertData = securityConvertData;
            _jwtGenerator = jWTGenerator;
            usersList = new List<User>()
            {
                new User() {
                    Name = "Admin",
                    Surname = "",
                    Email = "admin@gmail.com",
                    DateOfBirth = new DateTime(2000,1,1),
                    Password = _securityConvertData.HashDataPassword("admin").Result,
                    DateLastEnter = DateTime.Now,
                    CountFalseEnter = 0,
                    Role = "Admin"
                }
            };
        }

        public async Task<Response<string>> Login(LoginModel login)
        {
            try
            {
                foreach(var user in usersList)
                {
                    if (user.Email.Equals(login.Email))
                    {
                        user.CountFalseEnter++;
                    }
                    if(user.Email.Equals(login.Email) && _securityConvertData.VerifyDataPassword(user.Password, login.Password).Result == true)
                    {
                        if (user.CountFalseEnter > 3)
                        {
                            user.CountFalseEnter = 0;
                            throw new Exception();
                        }
                        user.DateLastEnter = DateTime.Now;
                        var token = await Task.Run(() => _jwtGenerator.GenerateJWT(user));
                        return token;
                    }
                }
                throw new Exception();
            }
            catch
            {
                return new Response<string>()
                {
                    Data = string.Empty,
                    StatusCode = new BadRequestResult().StatusCode,
                    Message = "Not Found User"
                };
            }
        }

        public async Task<Response<User>> Registration(RegistrationModel registrationModel)
        {
            try
            {
                var password = _securityConvertData.HashDataPassword(registrationModel.Password).Result;
                await Task.Run(() => usersList.Add(new User()
                {
                    Name = registrationModel.Name,
                    Surname = registrationModel.Surname,
                    Email = registrationModel.Email,
                    DateOfBirth = registrationModel.DateOfBirth,
                    Password = password,
                    Role = registrationModel.Role,
                }));
                return new Response<User>()
                {
                    Data = usersList.Last<User>(),
                    StatusCode = new OkResult().StatusCode,
                    Message = "Registration Success"
                };
            }
            catch
            {
                return new Response<User>()
                {
                    Data = null,
                    StatusCode = new BadRequestResult().StatusCode,
                    Message = "Registration Failed"
                };
            }
        }
    }
}
