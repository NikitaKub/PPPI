namespace PPPI.Services.SecurityConvert
{
    public interface ISecurityConvertData
    {
        Task <String> HashDataPassword(string password);
        Task <bool> VerifyDataPassword(string hashedPassword, string password);
    }
}
