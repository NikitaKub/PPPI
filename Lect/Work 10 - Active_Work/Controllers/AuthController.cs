using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PPPI.Models;
using PPPI.Services.JWTGenerator;
using PPPI.Services.UserAuth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PPPI.Controllers
{
    [ApiVersion("1.0", Deprecated = true)]
    [ApiVersion("2.0")]
    [ApiVersion("3.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserData _userData;

        public AuthController(IUserData userData)
        {
            _userData = userData;
        }

        [HttpPost, Route("login"), AllowAnonymous]
        public async Task<Response<string>> Login([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return new Response<string>()
                {
                    Data = ModelState.IsValid.ToString(),
                    Message = "Incorrect email or password type",
                    StatusCode = new BadRequestResult().StatusCode
                };
            }
            Response<string>? response = await _userData.Login(loginModel);
            return response;
        }

        [HttpPost, Route("registration"), Authorize(Roles = "Admin")]
        public async Task<Response<User>> Registration([FromBody] RegistrationModel registrationModel)
        {
            if (!ModelState.IsValid)
            {
                return new Response<User>()
                {
                    Data = null,
                    Message = "Incorrect data",
                    StatusCode = new BadRequestResult().StatusCode
                };
            }
            Response<User>? response = await _userData.Registration(registrationModel);
            return response;
        }
    }
}
