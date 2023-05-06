using PPPI.Models;

namespace PPPI.Services.JWTGenerator
{
    public interface IJWTGenerator
    {
        Response<string> GenerateJWT(User user);
    }
}
