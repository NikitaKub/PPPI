namespace PPPI.Services.SecurityConvert
{
    public interface ISecurityConvertData
    {
        Task<string> HashDataPassword(string password);
        Task<bool> VerifyDataPassword(string hashedPassword, string password);
    }
}
