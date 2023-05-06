using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PPPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PPPI.Services.JWTGenerator
{
    public class JWTGenerator : IJWTGenerator
    {
        private readonly IConfiguration _configuration;

        public JWTGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Response<string> GenerateJWT(User user)
        {
            try
            {
                Response<string> response = new Response<string>();

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("freecodeSecretKey"));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[] {
                             new Claim(JwtRegisteredClaimNames.Email, user.Email),
                             new Claim("roles", user.Role),
                             new Claim("Date", DateTime.Now.ToString()),
                             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var token = new JwtSecurityToken(
                    "freecodespot.com",
                    "freecodespot.com",
                    claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials);

                response.Data = new JwtSecurityTokenHandler().WriteToken(token);
                response.StatusCode = new OkResult().StatusCode;
                response.Message = "Token generated";
                return response;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return new Response<string>()
                {
                    Data = String.Empty,
                    StatusCode = new BadRequestResult().StatusCode,
                    Message = "Token not generated"
                };
            }
        }
    }
}
