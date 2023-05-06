using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PPPI.Models
{
    public class RegistrationModel
    {
        [StringLength(15)] public string Name { get; set; } = "User";
        [StringLength(15)] public string Surname { get; set; } = "";
        [Required][EmailAddress] public string Email { get; set; }
        [Required][DataType(DataType.Date)] public DateTime DateOfBirth { get; set; }
        [Required] public string Password { get; set; }
        [Required] public string Role { get; set; }
    }
}
