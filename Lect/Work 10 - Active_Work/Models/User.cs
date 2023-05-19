using System.ComponentModel.DataAnnotations;

namespace PPPI.Models
{
    public class User
    {
        public string Name { get; set; } = "User";
        public string Surname { get; set; } = "";
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Password { get; set; }
        public DateTime DateLastEnter { get; set; } = DateTime.Now;
        public int CountFalseEnter { get; set; } = 0;
        public string Role { get; set; }
    }
}
